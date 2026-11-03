using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Turtle_Data_Form : Form
    {
        private Fuzzy_Turtle_Pad_Form padForm = new Fuzzy_Turtle_Pad_Form();

        public Fuzzy_Turtle_Data_Form()
        {
            InitializeComponent();
        }

        private void Fuzzy_Turtle_Data_Form_Load(object sender, EventArgs e)
        {
            padForm.MdiParent = this.MdiParent;
            padForm.StartPosition = FormStartPosition.Manual;
            padForm.Left = this.Right;
            padForm.Show();

            cmbTurtleCommands.Items.Add("<no operation>");
            cmbTurtleCommands.Items.Add("Move Foward");
            cmbTurtleCommands.Items.Add("Move Backward");
            cmbTurtleCommands.Items.Add("Move Right");
            cmbTurtleCommands.Items.Add("Move Left");
            cmbTurtleCommands.Items.Add("Rotate Clockwise");
            cmbTurtleCommands.Items.Add("Rotate Counterclockwise");
            cmbTurtleCommands.Items.Add("Pen Up");
            cmbTurtleCommands.Items.Add("Pen Down");
            cmbTurtleCommands.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padForm.Close();
            this.Close();
        }

        List<string> cmdsToChooseFrom = new List<string>(new string[] { "F", "B", "R", "L", "C", "CC", "UP", "DN" });
        private void cmbTurtleCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurtleCommands.SelectedIndex != 0)
            {
                int idx = cmbTurtleCommands.SelectedIndex;
                if (txtTurtleCommand.Text.Length > 0) { txtTurtleCommand.AppendText(" "); }
                txtTurtleCommand.AppendText(cmdsToChooseFrom[idx - 1]);
            }
        }

        private void btnExecuteCommands_Click(object sender, EventArgs e)
        {
            string cmds = txtTurtleCommand.Text;
            padForm.Run_Commands(cmds);
        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            cmbTurtleCommands_SelectedIndexChanged(sender, e);
        }
    }
}
