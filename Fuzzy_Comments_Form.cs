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
    public partial class Fuzzy_Comments_Form : Form
    {
        private bool commentSaved = true;
        private bool formLoading = false;

        public Fuzzy_Comments_Form()
        {
            InitializeComponent();
        }

        private void Fuzzy_Comments_Load(object sender, EventArgs e)
        {
            formLoading = true;
            txtComments.Text = Global.Comment;
            formLoading = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtComments.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!commentSaved)
            {
                if (MessageBox.Show("Sae Comments?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Global.Comment = txtComments.Text;
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
