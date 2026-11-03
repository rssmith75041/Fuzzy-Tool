using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_System_Configuration_Setup_Form : Form
    {
        private const string toolTip = "Adjust how strongly each fuzzy category influences the controller.\r\n" +
                "Higher values = stronger response.\r\nLeave at 1.0 for normal behavior.";
        private bool catChangesApplied = true;
        private bool xWeightsSaved = true;
        private bool catSaved = true;

        private bool formLoading = false;

        #region Form
        public Fuzzy_System_Configuration_Setup_Form()
        {
            InitializeComponent();
            formLoading = true;
        }

        private void Fuzzy_System_Configuration_Setup_Form_Load(object sender, EventArgs e)
        {
            formLoading = true;
            toolTipResponseWeights.SetToolTip(gbXGridValues, toolTip);
            Load_Categories();
            Load_ED_Weights();
            Load_Equations();
            Load_Ideal_States();
            Load_Fuzzy_Sets();
            Load_Startup_Variables();

            foreach (RadioButton rb in gbOptions.Controls)
            {
                if (rb.Tag != null && int.Parse((string)rb.Tag) == Global.ImplicationRule)
                {
                    rb.Checked = true;
                    break;
                }
            }

            Configure_Fuzzy_Sets_Grid();
            formLoading = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!catSaved)
            {
                if (MessageBox.Show("Apply Changes?", "Not Saved", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Save to file
                    btnSave_Click(sender, e);
                }
            }

            this.Close();
        }

        private JsonSerializerOptions optionsWrite = new JsonSerializerOptions
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
            IncludeFields = true,
            WriteIndented = true
        };

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!catChangesApplied)
            {
                btnApplyCategories.Enabled = false;
                catChangesApplied = true;
                Apply_Categories();
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FilterIndex = 1;
            sfd.Filter = "Fuzzy Tool Project (*.json)|*.json";
            sfd.DefaultExt = "json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Text = $"FuzzyTool [{sfd.FileName}]";
                var gslc = Global_Save_Load_Class.ToData();
                string json = JsonSerializer.Serialize(gslc, optionsWrite);
                File.WriteAllText(sfd.FileName, json);
                btnApplyEDWeights.Enabled = false;
                catSaved = true;
            }
        }

        private JsonSerializerOptions optionsLoad = new JsonSerializerOptions
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
            IncludeFields = true
        };

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            ofd.Filter = "Fuzzy Tool Project (*.json)|*.json";
            ofd.DefaultExt = "json";
            ofd.FileName = "*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.Text = $"FuzzyTool [{ofd.FileName}]";
                string json = File.ReadAllText(ofd.FileName);
                Global_Save_Load_Class? loaded = JsonSerializer.Deserialize<Global_Save_Load_Class>(json, optionsLoad);
                if (loaded != null)
                {
                    loaded.FromData();
                    this.SuspendLayout();           // <- not working
                    formLoading = true;
                    Load_Categories();
                    Load_ED_Weights();
                    Load_Equations();
                    Load_Ideal_States();
                    Load_Fuzzy_Sets();
                    Load_Startup_Variables();
                    udStepH.Value = (decimal)Global.Step_h;
                    formLoading = false;
                    this.ResumeLayout();
                }
            }
        }
        #endregion

        #region Categories
        private void btnApplyCategories_Click(object sender, EventArgs e)
        {
            catChangesApplied = true;
            Apply_Categories();
        }

        private void Load_Categories()
        {
            txtNL.Text = Global.CategoryValues[0] == float.NegativeInfinity ? "-INF" : Global.CategoryValues[0].ToString(); //must be like -100
            txtNL.Tag = txtNL.Text;
            txtNM.Text = Global.CategoryValues[1].ToString(); //must be like -50
            txtNM.Tag = txtNM.Text;
            txtNS.Text = Global.CategoryValues[2].ToString(); //must be like -20
            txtNS.Tag = txtNS.Text;
            txtZE.Text = Global.CategoryValues[3].ToString(); //must be middle
            txtZE.Tag = txtZE.Text;
            txtPS.Text = Global.CategoryValues[4].ToString(); //must be like 20
            txtPS.Tag = txtPS.Text;
            txtPM.Text = Global.CategoryValues[5].ToString(); //must be like 50
            txtPM.Tag = txtPM.Text;
            txtPL.Text = Global.CategoryValues[6] == float.PositiveInfinity ? "INF" : Global.CategoryValues[6].ToString(); //must be like 100
            txtPL.Tag = txtPL.Text;
        }

        private void Apply_Categories()
        {
            Global.CategoryValues[0] = ckbNLAsIninity.Checked ? float.NegativeInfinity : float.Parse(txtNL.Text);
            Global.CategoryValues[1] = float.Parse(txtNM.Text);
            Global.CategoryValues[2] = float.Parse(txtNS.Text);
            Global.CategoryValues[3] = float.Parse(txtZE.Text);
            Global.CategoryValues[4] = float.Parse(txtPS.Text);
            Global.CategoryValues[5] = float.Parse(txtPM.Text);
            Global.CategoryValues[6] = ckbPLAsInfinity.Checked ? float.PositiveInfinity : float.Parse(txtPL.Text);
            btnApplyCategories.Enabled = false;
        }

        private void ckbPLAsInfinity_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPLAsInfinity.Checked)
            {
                Global.CategoryValues[6] = float.PositiveInfinity;
                txtPL.Enabled = false;
                txtPL.Text = "INF";
            }
            else
            {
                txtPL.Enabled = true;
                txtPL.Text = "100";
            }
        }

        private void ckbNLAsIninity_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNLAsIninity.Checked)
            {
                Global.CategoryValues[0] = float.NegativeInfinity;
                txtNL.Enabled = false;
                txtNL.Text = "-INF";
            }
            else
            {
                txtNL.Enabled = true;
                txtNL.Text = "-100";
            }
        }

        private void Category_TextBox_Leave(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (((TextBox)sender).Tag != null && ((TextBox)sender).Tag!.ToString() != ((TextBox)sender).Text)
                {
                    btnApplyCategories.Enabled = true;
                    catChangesApplied = false;
                    catSaved = false;
                }
            }
        }
        #endregion

        #region E-Error and d-Error
        private void Load_ED_Weights()
        {
            udENL.Value = (decimal)Global.X_Weights[0];
            udENL.Tag = udENL.Value;
            udENM.Value = (decimal)Global.X_Weights[1];
            udENM.Tag = udENM.Value;
            udENS.Value = (decimal)Global.X_Weights[2];
            udENS.Tag = udENS.Value;
            udEZE.Value = (decimal)Global.X_Weights[3];
            udEZE.Tag = udEZE.Value;
            udEPS.Value = (decimal)Global.X_Weights[4];
            udEPS.Tag = udEPS.Value;
            udEPM.Value = (decimal)Global.X_Weights[5];
            udEPM.Tag = udEPM.Value;
            udEPL.Value = (decimal)Global.X_Weights[6];
            udEPL.Tag = udEPL.Value;

            udDNL.Value = (decimal)Global.X_Weights[7];
            udDNL.Tag = udDNL.Value;
            udDNM.Value = (decimal)Global.X_Weights[8];
            udDNM.Tag = udDNM.Value;
            udDNS.Value = (decimal)Global.X_Weights[9];
            udDNS.Tag = udDNS.Value;
            udDZE.Value = (decimal)Global.X_Weights[10];
            udDZE.Tag = udDZE.Value;
            udDPS.Value = (decimal)Global.X_Weights[11];
            udDPS.Tag = udDPS.Value;
            udDPM.Value = (decimal)Global.X_Weights[12];
            udDPM.Tag = udDPM.Value;
            udDPL.Value = (decimal)Global.X_Weights[13];
            udDPL.Tag = udDPL.Value;
        }

        private void btnApplyEDWeights_Click(object sender, EventArgs e)
        {
            Global.X_Weights[0] = (float)udENL.Value;
            udENL.Tag = udENL.Value;
            Global.X_Weights[1] = (float)udENM.Value;
            udENM.Tag = udENM.Value;
            Global.X_Weights[2] = (float)udENS.Value;
            udENS.Tag = udENS.Value;
            Global.X_Weights[3] = (float)udEZE.Value;
            udEZE.Tag = udEZE.Value;
            Global.X_Weights[4] = (float)udEPS.Value;
            udEPS.Tag = udEPS.Value;
            Global.X_Weights[5] = (float)udEPM.Value;
            udEPM.Tag = udEPM.Value;
            Global.X_Weights[6] = (float)udEPL.Value;
            udEPL.Tag = udEPL.Value;

            Global.X_Weights[7] = (float)udDNL.Value;
            udDNL.Tag = udDNL.Value;
            Global.X_Weights[8] = (float)udDNM.Value;
            udDNM.Tag = udDNM.Value;
            Global.X_Weights[9] = (float)udDNS.Value;
            udDNS.Tag = udDNS.Value;
            Global.X_Weights[10] = (float)udDZE.Value;
            udDZE.Tag = udDZE.Value;
            Global.X_Weights[11] = (float)udDPS.Value;
            udDPS.Tag = udDPS.Value;
            Global.X_Weights[12] = (float)udDPM.Value;
            udDPM.Tag = udDPM.Value;
            Global.X_Weights[13] = (float)udDPL.Value;
            udDPL.Tag = udDPL.Value;

            xWeightsSaved = true;
            btnApplyEDWeights.Enabled = false;
        }

        private void UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }
            if (((NumericUpDown)sender).Tag != null)
            {
                if (((NumericUpDown)sender).Value != (decimal)((NumericUpDown)sender).Tag!)
                {
                    if (!btnApplyEDWeights.Enabled) { btnApplyEDWeights.Enabled = true; }
                }
            }
        }
        #endregion

        #region Equations
        private void Load_Equations()
        {
            if (Global.Equations != null)
            {
                if (Global.Equations.Length is 3)
                {
                    ckbThirdEquation.Checked = true;
                    txtEquation1.Text = Global.Equations[0];
                    txtEquation2.Text = Global.Equations[1];
                    txtEquation3.Text = Global.Equations[2];

                    udEquationVar2.Value = (decimal)Global.InitialState[0];
                    udEquationVar2.Tag = (decimal)Global.InitialState[0];
                    udEquationVar1.Value = (decimal)Global.InitialState[1];
                    udEquationVar1.Tag = (decimal)Global.InitialState[1];
                    udEquationVar3.Value = (decimal)Global.InitialState[2];
                    udEquationVar3.Tag = (decimal)Global.InitialState[2];
                }
                else
                {
                    ckbThirdEquation.Checked = false;
                    txtEquation1.Text = Global.Equations[0];
                    txtEquation2.Text = Global.Equations[1];

                    udEquationVar2.Value = (decimal)Global.InitialState[0];
                    udEquationVar2.Tag = (decimal)Global.InitialState[0];
                    udEquationVar1.Value = (decimal)Global.InitialState[1];
                    udEquationVar1.Tag = (decimal)Global.InitialState[1];
                }

                btnTest.Enabled = true;
            }
        }

        private void UpDownEqVar_ValueChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }
            if (((NumericUpDown)sender).Tag != null)
            {
                if (((NumericUpDown)sender).Value != (decimal)((NumericUpDown)sender).Tag!)
                {
                    if (!btnApplyEquations.Enabled) { btnApplyEquations.Enabled = true; }
                }
            }
        }

        private void txtEquations_TextChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }
            btnApplyEquations.Enabled = true;
        }

        private void ckbThirdEquation_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbThirdEquation.Checked)
            {
                txtEquation3.Enabled = true;
                lblEquation3.Enabled = true;
                udEquationVar3.Enabled = true;
            }
            else
            {
                txtEquation3.Enabled = false;
                lblEquation3.Enabled = false;
                udEquationVar3.Enabled = false;
                txtEquation3.Text = "";
            }
        }

        private void btnApplyEquationss_Click(object sender, EventArgs e)
        {
            if (ckbThirdEquation.Checked)
            {
                if (txtEquation1.Text == "" || txtEquation2.Text == "" || txtEquation3.Text == "")
                {
                    MessageBox.Show("Must have an equation for each one.", "Must Have");
                }
                else
                {
                    Global.Equations = new string[3];
                    Global.Equations[0] = txtEquation1.Text;
                    Global.Equations[1] = txtEquation2.Text;
                    Global.Equations[2] = txtEquation3.Text;

                    Global.InitialState = new float[3];
                    Global.InitialState[0] = (float)udEquationVar2.Value;
                    Global.InitialState[1] = (float)udEquationVar1.Value;
                    Global.InitialState[2] = (float)udEquationVar3.Value;

                    Global.CurrentState = new float[3];
                    Global.CurrentState[0] = (float)udEquationVar2.Value;
                    Global.CurrentState[1] = (float)udEquationVar1.Value;
                    Global.CurrentState[2] = (float)udEquationVar3.Value;
                    btnTest.Enabled = true;
                }
            }
            else
            {
                if (txtEquation1.Text == "" || txtEquation2.Text == "")
                {
                    MessageBox.Show("Must have an equation for each one.", "Must Have");
                }
                else
                {
                    Global.Equations = new string[2];
                    Global.Equations[0] = txtEquation1.Text;
                    Global.Equations[1] = txtEquation2.Text;

                    Global.InitialState = new float[2];
                    Global.InitialState[0] = (float)udEquationVar2.Value;
                    Global.InitialState[1] = (float)udEquationVar1.Value;

                    Global.CurrentState = new float[2];
                    Global.CurrentState[0] = (float)udEquationVar2.Value;
                    Global.CurrentState[1] = (float)udEquationVar1.Value;
                    btnTest.Enabled = true;
                }
            }

            btnApplyEquations.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.Equations == null || Global.InitialState == null) { return; }
                // 1. Collect equations from UI
                float[] initials = Global.InitialState;
                string[] eqs = Global.Equations!;
                ParserModern p = new ParserModern();

                // 2. Validate equation count vs initial state count
                if (Global.InitialState.Length != Global.Equations!.Length)
                {
                    string msg = $"Initial state count ({initials.Length}) does not match equation count ({eqs.Length}).";
                    MessageBox.Show(msg, "System Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Try a single RK4 step using your solver
                float[] finalState;
                try { p.Process_Equations_N(eqs, 0.01f, 0f, initials, out finalState, 1); }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error evaluating system:\n{ex.Message}", "System Test Failed", MessageBoxButtons.OK);
                    return;
                }

                // 4. If we reach here, everything is valid
                MessageBox.Show("System test passed.\nAll equations and initial states are valid.", "System Test Successful", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}", "System Test Failed", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void rbImplications_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }

            foreach (RadioButton rb in gbOptions.Controls)
            {
                if (rb.Checked)
                {
                    Global.ImplicationRule = (int)rb.Tag!;
                    break;
                }
            }
        }

        #region Ideal States
        //Legacy System
        private void Load_Ideal_States()
        {
            txtIdealStatedE.Text = Global.IdealState[1].ToString();
            txtIdealStateX.Text = Global.IdealState[0].ToString();
        }

        private void btnApplyIdealStates_Click(object sender, EventArgs e)
        {
            Global.IdealState[0] = float.Parse(txtIdealStateX.Text);
            Global.IdealState[1] = float.Parse(txtIdealStatedE.Text);
        }
        #endregion

        private void Configure_Fuzzy_Sets_Grid()
        {
            tblSets.AutoSize = false;
            tblSets.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblSets.ColumnCount = 5; // Set, P0, P1, P2, P3
            tblSets.RowCount = 8;    // header + 7 sets
            // 1. Set column sizes
            tblSets.ColumnStyles.Clear();
            tblSets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60)); // Set label
            tblSets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80)); // P0
            tblSets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80)); // P1
            tblSets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80)); // P2
            tblSets.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80)); // P3
            // 2. Set row sizes
            tblSets.RowStyles.Clear();
            for (int r = 0; r < 8; r++) { tblSets.RowStyles.Add(new RowStyle(SizeType.Absolute, 28)); }
            // 3. Optional: grid lines + fixed size
            tblSets.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tblSets.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        private TextBox[,] cells = new TextBox[7, 4];
        private string[,] backup = new string[7, 4];

        private void Load_Fuzzy_Sets()
        {
            if (Global.FuzzySet.Length < 28) { MessageBox.Show("Invalid fuzzy set."); return; }
            tblSets.SuspendLayout();
            tblSets.Controls.Clear();
            // Header row
            tblSets.Controls.Add(new Label() { Text = "Set", AutoSize = true }, 0, 0);
            tblSets.Controls.Add(new Label() { Text = "P0", AutoSize = true }, 1, 0);
            tblSets.Controls.Add(new Label() { Text = "P1", AutoSize = true }, 2, 0);
            tblSets.Controls.Add(new Label() { Text = "P2", AutoSize = true }, 3, 0);
            tblSets.Controls.Add(new Label() { Text = "P3", AutoSize = true }, 4, 0);

            for (int j = 0; j < 7; j++)
            {
                switch (j)
                {
                    case 6: { tblSets.Controls.Add(new Label() { Text = "PL", AutoSize = true }, 0, j + 1); } break;
                    case 5: { tblSets.Controls.Add(new Label() { Text = "PM", AutoSize = true }, 0, j + 1); } break;
                    case 4: { tblSets.Controls.Add(new Label() { Text = "PS", AutoSize = true }, 0, j + 1); } break;
                    case 3: { tblSets.Controls.Add(new Label() { Text = "ZE", AutoSize = true }, 0, j + 1); } break;
                    case 2: { tblSets.Controls.Add(new Label() { Text = "NS", AutoSize = true }, 0, j + 1); } break;
                    case 1: { tblSets.Controls.Add(new Label() { Text = "NM", AutoSize = true }, 0, j + 1); } break;
                    case 0: { tblSets.Controls.Add(new Label() { Text = "NL", AutoSize = true }, 0, j + 1); } break;
                }

                for (int i = 0; i < 4; i++)
                {
                    var tb = new TextBox()
                    {
                        Text = Global.FuzzySet[j, i],
                        Width = 70,
                        Height = 22,
                        Anchor = AnchorStyles.Left
                    };

                    if (tb.Text == "INF" || tb.Text == "-INF")
                    {
                        if (tb.Text == "INF") { ckbFuzzySetPLAsInfinity.Checked = true; }
                        else { ckbFuzzySetNLNegInfinity.Checked = true; }
                        tb.Enabled = false;
                    }

                    cells[j, i] = tb;
                    tblSets.Controls.Add(tb, i + 1, j + 1);
                }
            }
            tblSets.ResumeLayout();

            // Copy loaded values into backup
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    backup[j, i] = cells[j, i].Text.Trim();
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Update global array
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Global.FuzzySet[j, i] = cells[j, i].Text.Trim();
                }
            }

            // Copy loaded values into backup
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    backup[j, i] = cells[j, i].Text.Trim();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tblSets.Controls.Clear();
            // Header row
            tblSets.Controls.Add(new Label() { Text = "Set", AutoSize = true }, 0, 0);
            tblSets.Controls.Add(new Label() { Text = "P0", AutoSize = true }, 1, 0);
            tblSets.Controls.Add(new Label() { Text = "P1", AutoSize = true }, 2, 0);
            tblSets.Controls.Add(new Label() { Text = "P2", AutoSize = true }, 3, 0);
            tblSets.Controls.Add(new Label() { Text = "P3", AutoSize = true }, 4, 0);

            for (int j = 0; j < 7; j++)
            {
                tblSets.Controls.Add(new Label() { Text = $"Set {j}", AutoSize = true }, 0, j + 1);

                for (int i = 0; i < 4; i++)
                {
                    var tb = new TextBox()
                    {
                        Text = backup[j, i],
                        Width = 70,
                        Height = 22,
                        Anchor = AnchorStyles.Left
                    };

                    if (tb.Text == "INF" || tb.Text == "-INF")
                    {
                        if (tb.Text == "INF") { ckbFuzzySetPLAsInfinity.Checked = true; }
                        else { ckbFuzzySetNLNegInfinity.Checked = true; }
                        tb.Enabled = false;
                    }

                    cells[j, i] = tb;
                    tblSets.Controls.Add(tb, i + 1, j + 1);
                }
            }
        }

        private void ckbFuzzySetPLAsInfinity_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }
            if (ckbFuzzySetPLAsInfinity.Checked)
            {
                cells[6, 3].Enabled = false;
                cells[6, 3].Text = "INF";
            }
            else
            {
                cells[6, 3].Enabled = true;
                cells[6, 3].Text = "";
            }
        }

        private void ckbFuzzySetNLNegInfinity_CheckedChanged(object sender, EventArgs e)
        {
            if (formLoading) { return; }
            if (ckbFuzzySetNLNegInfinity.Checked)
            {
                cells[0, 0].Enabled = false;
                cells[0, 0].Text = "-INF";
            }
            else
            {
                cells[0, 0].Enabled = true;
                cells[0, 0].Text = "";
            }
        }


        //Load Startup Variables
        private void Load_Startup_Variables()
        {
            udReactionInterval.Value = Global.Interval;
            udMaxIterations.Value = Global.MaxIter;
            udStepH.Value = (decimal)Global.Step_h;

            switch (Global.Which_Parser)
            {
                case 0: { rbModern.Checked = true; } break;
                case 1: { rbLegacy.Checked = true; } break;
            }
        }

        private void btnStartupVariablesApply_Click(object sender, EventArgs e)
        {
            Global.Interval = (int)udReactionInterval.Value;
            Global.MaxIter = (int)udMaxIterations.Value;
            Global.Which_Parser = rbModern.Checked ? 0 : 1;
            Global.Step_h = (float)udStepH.Value;

            Global.FuzzyControlForm?.Update_Parser_Message();
        }



        private void btnAddComment_Click(object sender, EventArgs e)
        {
            Fuzzy_Comments_Form fcf = new Fuzzy_Comments_Form();
            fcf.MdiParent = this.MdiParent;
            fcf.Show();
        }
    }
}
