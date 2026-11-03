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
    public partial class Fuzzy_About_Form : Form
    {
        public Fuzzy_About_Form()
        {
            InitializeComponent();
            txtMessage.Text = "FuzzyTool 2.0 Copyright (C) 2026";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
