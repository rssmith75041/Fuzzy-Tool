using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Test_Form : Form
    {
        private readonly string testEq = "SIN(1)/COS(1)";
        private string answer = string.Empty;

        public Fuzzy_Test_Form()
        {
            InitializeComponent();
            txtEquation.Text = testEq;
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            if (rbLegacy.Checked)
            {
                Parser p = new Parser();
                int error = p.X_Evaluate(txtEquation.Text, ref answer);
                txtAnswer.Text = answer;
                txtError.Text = $"Error No: {p.Error_No} -> {p.Error_Str}";
            }
            else
            {
                ParserModern pm = new ParserModern();
                float retValue = pm.Evaluate(txtEquation.Text);
                txtAnswer.Text = retValue.ToString();
                txtError.Text = $"Error No: {pm.Error_No} -> {pm.Error_Str}";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
