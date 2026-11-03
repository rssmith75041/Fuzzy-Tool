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
    public partial class TestParserForm : Form
    {
        public TestParserForm()
        {
            InitializeComponent();
        }

        private void btnTestParser_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser();
            float value = parser.Evaluate(txtEquation.Text);
            txtAnswer.Text = value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
