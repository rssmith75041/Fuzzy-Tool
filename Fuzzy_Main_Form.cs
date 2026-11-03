using Microsoft.VisualBasic.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Main_Form : Form
    {
        private string helpFile = @"\FUZZTOOL.TXT";

        public Fuzzy_Main_Form()
        {
            InitializeComponent();
            Global.ResetBlankProject();
            Global.Executing = false;
            Global.Stepping = false;
        }

        private void Fuzzy_Main_Form_Load(object sender, EventArgs e)
        {
            Global.FuzzyMainForm = this;
            Global.ResetBlankProject();
            Global.Executing = false;
            Global.Stepping = false;
        }

        private void FuzzyMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Stop_Execution = true;
            Application.DoEvents();

            if (!Global.Fuzsaved || !Global.Setsaved || !Global.Rulsaved)
            {
                DialogResult dr = MessageBox.Show("The current project has changed! Do you wish to save it?", "Save?",
                    MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            //Yes, Save it!
                            Global.Fuzsaved = true;
                            saveProjectToolStripMenuItem_Click(sender, EventArgs.Empty);
                        }
                        break;
                    case DialogResult.Cancel:
                    case DialogResult.No: { Global.Cancel = true; } break;
                }
            }
        }

        private void testParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestParserForm tpf = new TestParserForm();
            tpf.MdiParent = this;
            tpf.Show();
        }

        private void testFuzzyFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_Test_Form ftf = new Fuzzy_Test_Form();
            ftf.MdiParent = this;
            ftf.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_System_Configuration_Setup_Form fscsf = new Fuzzy_System_Configuration_Setup_Form();
            fscsf.MdiParent = this;
            fscsf.Show();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Global.Fuzsaved || !Global.Setsaved || !Global.Rulsaved)
            {
                DialogResult dr = MessageBox.Show("The current project has changed! Do you wish to save it?", "Save?", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            //Yes, Save it!
                            Global.Fuzsaved = true;
                            saveProjectToolStripMenuItem_Click(sender, EventArgs.Empty);
                        }
                        break;
                    case DialogResult.No: { } break;
                }
            }

            OpenFileDialog cmdFileDialog = new OpenFileDialog();
            cmdFileDialog.FilterIndex = 1;
            cmdFileDialog.Filter = "Fuzzy Tool Project (*.json)|*.json|All Files (*.*)|*.*";
            cmdFileDialog.DefaultExt = "json";
            cmdFileDialog.FileName = "*.json";

            if (cmdFileDialog.ShowDialog() == DialogResult.OK)
            {
                Global.ResetBlankProject();
                Load_Json_Project_File(cmdFileDialog.FileName);
                Global.FuzzyControlForm!.Close();
                Global.FuzzyFiringForm!.Close();

                Global.FuzzyControlForm = new Fuzzy_Control_Form();
                Global.FuzzyControlForm.MdiParent = this;
                Global.FuzzyControlForm.Top = 0;
                Global.FuzzyControlForm.Show();

                Global.FuzzyFiringForm = new Fuzzy_Firing_Form();
                Global.FuzzyFiringForm.MdiParent = this;
                Global.FuzzyFiringForm.StartPosition = FormStartPosition.Manual;
                Global.FuzzyFiringForm.Left = Global.FuzzyControlForm.Right;
                Global.FuzzyFiringForm.Top = 0;
                Global.FuzzyFiringForm.Show();
                Global.FuzzyFiringForm.Fuzzy_Values = Global.CategoryValues;
            }
        }

        private JsonSerializerOptions optionsLoad = new JsonSerializerOptions
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
            IncludeFields = true
        };

        private void Load_Json_Project_File(string jsonFile)
        {
            this.Text = $"FuzzyTool [{jsonFile}]";
            string json = File.ReadAllText(jsonFile);
            Global_Save_Load_Class? loaded = JsonSerializer.Deserialize<Global_Save_Load_Class>(json, optionsLoad);
            if (loaded != null)
            {
                loaded.FromData();
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FilterIndex = 1;
            sfd.Filter = "Fuzzy Tool Project (*.json)|*.json|All Files (*.*)|*.*";
            sfd.DefaultExt = "json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Save_To_Json_File(sfd.FileName);
            }
        }

        private JsonSerializerOptions optionsWrite = new JsonSerializerOptions
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
            IncludeFields = true,
            WriteIndented = true
        };

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FilterIndex = 1;
            sfd.Filter = "Fuzzy Tool Project (*.json)|*.json|All Files (*.*)|*.*";
            sfd.DefaultExt = "json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Save_To_Json_File(sfd.FileName);
            }
        }

        private void Save_To_Json_File(string fileName)
        {
            this.Text = $"FuzzyTool [{fileName}]";
            var gslc = Global_Save_Load_Class.ToData();
            string json = JsonSerializer.Serialize(gslc, optionsWrite);
            File.WriteAllText(fileName, json);
        }

        private void editCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_Comments_Form fcf = new Fuzzy_Comments_Form();
            fcf.MdiParent = this;
            fcf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xVelocityAsDErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.XVelocityAsdError = !Global.XVelocityAsdError;
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arrange 0
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arrange 1
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arrange 2
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_About_Form fa = new Fuzzy_About_Form();
            fa.MdiParent = this;
            fa.Show();
        }

        private void Show_Commentbox()
        {
            Fuzzy_Comments_Form fcf = new Fuzzy_Comments_Form();
            fcf.MdiParent = this;
            fcf.Show();
        }

        private void executionWindowStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.FuzzyForm = new Fuzzy_Form();
            Global.FuzzyForm.MdiParent = this;
            Global.FuzzyForm.Show();
        }

        private void systemSetupStripMenuItem1_Click(object sender, EventArgs e)
        {
            Fuzzy_System_Configuration_Setup_Form fscsf = new Fuzzy_System_Configuration_Setup_Form();
            fscsf.MdiParent = this;
            fscsf.Show();
        }

        public FuzzyVariable ErrorVar = new FuzzyVariable { Name = "Error", Min = -100, Max = 100 };
        public FuzzyVariable DErrorVar = new FuzzyVariable { Name = "dError", Min = -100, Max = 100 };
        public FuzzyVariable OutputVar = new FuzzyVariable { Name = "Output", Min = -100, Max = 100 };
        public List<FuzzyRule> Rules = new List<FuzzyRule>();

        private void fuzzyWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_WorkSpace_Form fwf = new Fuzzy_WorkSpace_Form(ErrorVar, DErrorVar, OutputVar, Rules);
            fwf.MdiParent = this;
            fwf.Show();
        }

        private void turtlePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuzzy_Turtle_Data_Form ftdf = new Fuzzy_Turtle_Data_Form();
            ftdf.MdiParent = this;
            ftdf.Show();
        }
    }
}
