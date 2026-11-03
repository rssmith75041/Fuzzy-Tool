using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_WorkSpace_Form : Form
    {
        private FuzzyVariable? dErrorVar;
        private FuzzyVariable? outputVar;
        private FuzzyVariable? errorVar;
        private List<FuzzyRule>? rules;

        private FuzzyVariable? currentVar;
        public Action? OnFuzzyChanged;

        public Fuzzy_WorkSpace_Form(FuzzyVariable e, FuzzyVariable de, FuzzyVariable outVar, List<FuzzyRule> ruleList)
        {
            InitializeComponent();

            errorVar = e;
            dErrorVar = de;
            outputVar = outVar;
            rules = ruleList;

            cmbVariable.Items.Add("Error");
            cmbVariable.Items.Add("dError");
            cmbVariable.Items.Add("Output");
            cmbVariable.SelectedIndex = 0;

            LoadVariable(errorVar);

            lstRules.DataSource = rules;
            lstRules.DisplayMember = nameof(FuzzyRule.OutputSet);

            RefreshRuleCombos();
        }

        private void LoadVariable(FuzzyVariable var)
        {
            currentVar = var;
            lstSets.DataSource = null;
            lstSets.DataSource = var.Sets;
            lstSets.DisplayMember = nameof(MembershipFunction.Name);
        }

        private void RefreshRuleCombos()
        {
            cmbErrorSet.Items.Clear();
            cmbDErrorSet.Items.Clear();
            cmbOutputSet.Items.Clear();

            foreach (var mf in errorVar!.Sets) { cmbErrorSet.Items.Add(mf.Name); }
            foreach (var mf in dErrorVar!.Sets) { cmbDErrorSet.Items.Add(mf.Name); }
            foreach (var mf in outputVar!.Sets) { cmbOutputSet.Items.Add(mf.Name); }
        }

        private void cmbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbVariable.SelectedItem!.ToString())
            {
                case "Error": LoadVariable(errorVar!); break;
                case "dError": LoadVariable(dErrorVar!); break;
                case "Output": LoadVariable(outputVar!); break;
            }
        }

        private void lstSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSets.SelectedItem is not MembershipFunction mf) { return; }
            txtName.Text = mf.Name;
            cmbShape.SelectedItem = mf.Shape;
            numA.Value = (decimal)mf.A;
            numB.Value = (decimal)mf.B;
            numC.Value = (decimal)mf.C;
            numD.Value = (decimal)mf.D;
            pbPreview.Invalidate();
        }

        private void SaveCurrentSet()
        {
            if (lstSets.SelectedItem is not MembershipFunction mf) { return; }
            mf.Name = txtName.Text;
            mf.Shape = cmbShape.Text;
            mf.A = (float)numA.Value;
            mf.B = (float)numB.Value;
            mf.C = (float)numC.Value;
            mf.D = (float)numD.Value;

            lstSets.Refresh();
            pbPreview.Invalidate();
            //OnFuzzyChanged?.Invoke();
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {
            var mf = new MembershipFunction
            {
                Name = txtName.Text,
                Shape = (string)cmbShape.SelectedItem!,
                A = (float)numA.Value,
                B = (float)numB.Value,
                C = (float)numC.Value,
                D = (float)numD.Value
            };

            currentVar!.Sets.Add(mf);
            LoadVariable(currentVar);
            RefreshRuleCombos();
            //OnFuzzyChanged?.Invoke();
        }

        private void btnDeleteSet_Click(object sender, EventArgs e)
        {
            if (lstSets.SelectedItem is MembershipFunction mf)
            {
                currentVar!.Sets.Remove(mf);
                LoadVariable(currentVar);
            }

            RefreshRuleCombos();
            //OnFuzzyChanged?.Invoke();
        }

        private void pbPreview_Paint(object sender, PaintEventArgs e)
        {
            if (lstSets.SelectedItem is not MembershipFunction mf) { return; }
            var g = e.Graphics;
            g.Clear(Color.White);

            float minX = currentVar!.Min;
            float maxX = currentVar!.Max;

            int w = pbPreview.Width;
            int h = pbPreview.Height;

            using var pen = new Pen(Color.Blue, 2);

            PointF[] pts = new PointF[w];

            for (int i = 0; i < w; i++)
            {
                float x = minX + (i / (float)w) * (maxX - minX);
                float y = mf.Compute(x);

                pts[i] = new PointF(i, h - y * h);
            }

            g.DrawLines(pen, pts);
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            if (cmbErrorSet.SelectedItem == null || cmbDErrorSet.SelectedItem == null || cmbOutputSet.SelectedItem == null) { return; }
            var rule = new FuzzyRule
            {
                ErrorSet = (string)cmbErrorSet.SelectedItem,
                DErrorSet = (string)cmbDErrorSet.SelectedItem,
                OutputSet = (string)cmbOutputSet.SelectedItem
            };

            rules!.Add(rule);
            lstRules.DataSource = null;
            lstRules.DataSource = rules;
            //OnFuzzyChanged?.Invoke();
            RefreshRuleMatrix();
        }

        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if (lstRules.SelectedItem is FuzzyRule rule)
            {
                rules!.Remove(rule);
                lstRules.DataSource = null;
                lstRules.DataSource = rules;
            }

            //OnFuzzyChanged?.Invoke();
            RefreshRuleMatrix();
        }

        private void AnySetValueChanged(object sender, EventArgs e)
        {
            //SaveCurrentSet();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            OnFuzzyChanged?.Invoke();
        }

        private void btnGenerate5StandardSets_Click(object sender, EventArgs e)
        {
            if (currentVar == null) return;

            void FillStandardSets(FuzzyVariable v)
            {
                v.Sets.Clear();
                v.Sets.Add(new MembershipFunction { Name = "NL", Shape = "Triangle", A = -100, B = -100, C = -50 });
                v.Sets.Add(new MembershipFunction { Name = "NS", Shape = "Triangle", A = -75, B = -50, C = -25 });
                v.Sets.Add(new MembershipFunction { Name = "Z", Shape = "Triangle", A = -10, B = 0, C = 10 });
                v.Sets.Add(new MembershipFunction { Name = "PS", Shape = "Triangle", A = 25, B = 50, C = 75 });
                v.Sets.Add(new MembershipFunction { Name = "PL", Shape = "Triangle", A = 50, B = 100, C = 100 });
            }


            FillStandardSets(currentVar); // Fill the currently selected variable
            if (dErrorVar != null && dErrorVar.Sets.Count == 0) { FillStandardSets(dErrorVar); }// Ensure dError also has sets

            LoadVariable(currentVar);
            RefreshRuleCombos();
            //OnFuzzyChanged?.Invoke();
        }

        private void btnGenerateRules_Click(object sender, EventArgs e)
        {
            string[] sets = { "NL", "NS", "Z", "PS", "PL" };
            rules!.Clear();

            foreach (var eSet in sets)
            {
                foreach (var deSet in sets)
                {
                    string outSet = "Z";

                    if (eSet == "NL") outSet = (deSet == "PL") ? "Z" : "NL";
                    if (eSet == "NS") outSet = (deSet == "PL") ? "PS" : "NS";
                    if (eSet == "Z") outSet = (deSet == "NL") ? "NS" : (deSet == "PL") ? "PS" : "Z";
                    if (eSet == "PS") outSet = (deSet == "NL") ? "Z" : (deSet == "PL") ? "PL" : "PS";
                    if (eSet == "PL") outSet = (deSet == "NL") ? "Z" : (deSet == "NS") ? "PS" : "PL";

                    rules.Add(new FuzzyRule
                    {
                        ErrorSet = eSet,
                        DErrorSet = deSet,
                        OutputSet = outSet
                    });
                }
            }

            lstRules.DataSource = null;
            lstRules.DataSource = rules;
            //OnFuzzyChanged?.Invoke();
            RefreshRuleMatrix();
        }

        private void RefreshRuleMatrix()
        {
            dgvRuleMatrix.Columns.Clear();
            dgvRuleMatrix.Rows.Clear();

            string[] sets = { "NL", "NS", "Z", "PS", "PL" };

            dgvRuleMatrix.Columns.Add("Error/dError", "Error \\ dError");
            foreach (var de in sets) { dgvRuleMatrix.Columns.Add(de, de); }
            foreach (DataGridViewColumn col in dgvRuleMatrix.Columns)
            {
                col.Width = 40;   // perfect size for NL / NS / Z / PS / PL
            }

            // Disable per-column autosizing
            for (int i = 0; i < dgvRuleMatrix.Columns.Count; i++)
            {
                dgvRuleMatrix.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            foreach (var eSet in sets)
            {
                int rowIndex = dgvRuleMatrix.Rows.Add();
                dgvRuleMatrix.Rows[rowIndex].Cells[0].Value = eSet;

                for (int i = 0; i < sets.Length; i++)
                {
                    string deSet = sets[i];
                    var rule = rules!.FirstOrDefault(r => r.ErrorSet == eSet && r.DErrorSet == deSet);
                    dgvRuleMatrix.Rows[rowIndex].Cells[i + 1].Value = rule != null ? rule.OutputSet : "";
                }
            }
        }

        private void lblSaveCurrentSet_Click(object sender, EventArgs e)
        {
            if (lstSets.SelectedItem is not MembershipFunction mf)
                return;

            mf.Name = txtName.Text;
            mf.Shape = cmbShape.Text;

            mf.A = (float)numA.Value;
            mf.B = (float)numB.Value;
            mf.C = (float)numC.Value;
            mf.D = (float)numD.Value;

            lstSets.Refresh();
        }
    }
}
