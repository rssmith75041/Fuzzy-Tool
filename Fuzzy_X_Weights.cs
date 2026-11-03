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
    public partial class Fuzzy_X_Weights : Form
    {
        private bool xWeightsSaved = true;
        private bool formLoading = false;

        public Fuzzy_X_Weights()
        {
            InitializeComponent();
            formLoading = true;
            Load_ED_Weights();
            formLoading = false;
        }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
