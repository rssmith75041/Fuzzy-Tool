using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzzy_Tool
{
    public partial class Fuzzy_Firing_Form : Form
    {
        public string Current_State_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"Current State[0]: {value}\r\n");
                    txtCurrentState.Text = value;
                }
            }
        }

        public string Category_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"{value}\r\n");
                    Fire_Fuzzy_Category(value);
                    txtCategory.Text = value;
                }
            }
        }

        public string xError_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"xError: {value}\r\n");
                    txtxError.Text = value;
                }
            }
        }

        public string dError_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"dError: {value}\r\n");
                    txtdError.Text = value;
                }
            }
        }

        public string Fuzzy_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"Fuzzy: {value}\r\n");
                    txtFuzzy.Text = value;
                }
            }
        }

        public string Youts_While_Firing
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtYOUTs.AppendText($"{value}\r\n");
                }
            }
        }

        public string Error_Messages
        {
            set
            {
                lock (txtYOUTs)
                {
                    txtErrorMsg.AppendText($"{value}\r\n");
                }
            }
        }

        public float[] Fuzzy_Values
        {
            set
            {
                txtNLVal.Text = value[0].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[0]: {value[0]}\r\n");
                txtNMVal.Text = value[1].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[1]: {value[1]}\r\n");
                txtNSVal.Text = value[2].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[2]: {value[2]}\r\n");
                txtZEVal.Text = value[3].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[3]: {value[3]}\r\n");
                txtPSVal.Text = value[4].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[4]: {value[4]}\r\n");
                txtPMVal.Text = value[5].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[5]: {value[5]}\r\n");
                txtPLVal.Text = value[6].ToString();
                txtYOUTs.AppendText($"Fuzzy Values[6]: {value[6]}\r\n");
            }
        }

        public Fuzzy_Firing_Form()
        {
            InitializeComponent();
        }

        public void Reset_All()
        {
            txtCurrentState.Text = "";
            txtCategory.Text = "";
            txtdError.Text = "";
            txtFuzzy.Text = "";

            txtNL.BackColor = Color.White;
            txtNM.BackColor = Color.White;
            txtNS.BackColor = Color.White;
            txtZE.BackColor = Color.White;
            txtPS.BackColor = Color.White;
            txtPM.BackColor = Color.White;
            txtPL.BackColor = Color.White;

            txtNLVal.Text = "";
            txtNMVal.Text = "";
            txtNSVal.Text = "";
            txtPSVal.Text = "";
            txtPMVal.Text = "";
            txtPLVal.Text = "";

            txtxError.Text = "";
            txtYOUTs.Text = "";
            txtZEVal.Text = "";
        }

        private void Fuzzy_Firing_Form_Load(object sender, EventArgs e)
        {
        }

        private void Fire_Fuzzy_Category(string fuzzyCategory)
        {
            string[] valueParts = fuzzyCategory.Split(':');
            Fuzzy_Clear_Fire();

            switch (valueParts[0].Trim())
            {
                case "PL": { txtPL.BackColor = Color.LightBlue; } break;
                case "PM": { txtPM.BackColor = Color.LightBlue; } break;
                case "PS": { txtPS.BackColor = Color.LightBlue; } break;
                case "ZE": { txtZE.BackColor = Color.LightGreen; } break;
                case "NS": { txtNL.BackColor = Color.LightCyan; } break;
                case "NM": { txtNM.BackColor = Color.LightCyan; } break;
                case "NL": { txtNL.BackColor = Color.LightCyan; } break;
            }
        }

        private void Fuzzy_Clear_Fire()
        {
            txtNL.BackColor = Color.White;
            txtNM.BackColor = Color.White;
            txtNS.BackColor = Color.White;
            txtZE.BackColor = Color.White;
            txtPL.BackColor = Color.White;
            txtPM.BackColor = Color.White;
            txtPS.BackColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Global.FuzzyControlForm!.Fuzzy_Firing_Form_Closed();
            Global.FuzzyFiringForm!.Dispose();
            Global.FuzzyFiringForm = null;
            this.Close();
        }
    }
}
