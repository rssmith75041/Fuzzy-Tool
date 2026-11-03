namespace Fuzzy_Tool
{
    partial class Fuzzy_X_Weights
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbXGridValues = new GroupBox();
            btnClose = new Button();
            udDNL = new NumericUpDown();
            udDNM = new NumericUpDown();
            udDNS = new NumericUpDown();
            udDZE = new NumericUpDown();
            udDPS = new NumericUpDown();
            udDPM = new NumericUpDown();
            udDPL = new NumericUpDown();
            udENL = new NumericUpDown();
            udENM = new NumericUpDown();
            udENS = new NumericUpDown();
            udEZE = new NumericUpDown();
            udEPS = new NumericUpDown();
            udEPM = new NumericUpDown();
            udEPL = new NumericUpDown();
            lblDPL = new Label();
            lblDPM = new Label();
            lblDPS = new Label();
            lblDNL = new Label();
            lblDZE = new Label();
            lblDNM = new Label();
            lblDNS = new Label();
            lblENS = new Label();
            btnApplyEDWeights = new Button();
            lblENM = new Label();
            lblEZE = new Label();
            lblENL = new Label();
            lblEPS = new Label();
            lblEPM = new Label();
            lblEPL = new Label();
            gbXGridValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)udDNL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDNM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDNS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDZE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDPS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDPM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udDPL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udENL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udENM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udENS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udEZE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udEPS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udEPM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)udEPL).BeginInit();
            SuspendLayout();
            // 
            // gbXGridValues
            // 
            gbXGridValues.Controls.Add(btnClose);
            gbXGridValues.Controls.Add(udDNL);
            gbXGridValues.Controls.Add(udDNM);
            gbXGridValues.Controls.Add(udDNS);
            gbXGridValues.Controls.Add(udDZE);
            gbXGridValues.Controls.Add(udDPS);
            gbXGridValues.Controls.Add(udDPM);
            gbXGridValues.Controls.Add(udDPL);
            gbXGridValues.Controls.Add(udENL);
            gbXGridValues.Controls.Add(udENM);
            gbXGridValues.Controls.Add(udENS);
            gbXGridValues.Controls.Add(udEZE);
            gbXGridValues.Controls.Add(udEPS);
            gbXGridValues.Controls.Add(udEPM);
            gbXGridValues.Controls.Add(udEPL);
            gbXGridValues.Controls.Add(lblDPL);
            gbXGridValues.Controls.Add(lblDPM);
            gbXGridValues.Controls.Add(lblDPS);
            gbXGridValues.Controls.Add(lblDNL);
            gbXGridValues.Controls.Add(lblDZE);
            gbXGridValues.Controls.Add(lblDNM);
            gbXGridValues.Controls.Add(lblDNS);
            gbXGridValues.Controls.Add(lblENS);
            gbXGridValues.Controls.Add(btnApplyEDWeights);
            gbXGridValues.Controls.Add(lblENM);
            gbXGridValues.Controls.Add(lblEZE);
            gbXGridValues.Controls.Add(lblENL);
            gbXGridValues.Controls.Add(lblEPS);
            gbXGridValues.Controls.Add(lblEPM);
            gbXGridValues.Controls.Add(lblEPL);
            gbXGridValues.Location = new Point(12, 11);
            gbXGridValues.Name = "gbXGridValues";
            gbXGridValues.Size = new Size(251, 268);
            gbXGridValues.TabIndex = 101;
            gbXGridValues.TabStop = false;
            gbXGridValues.Text = "Override Response Wieghts (Advanced)";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(45, 236);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(169, 23);
            btnClose.TabIndex = 135;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // udDNL
            // 
            udDNL.DecimalPlaces = 2;
            udDNL.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDNL.Location = new Point(177, 177);
            udDNL.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDNL.Name = "udDNL";
            udDNL.Size = new Size(53, 23);
            udDNL.TabIndex = 134;
            udDNL.ValueChanged += UpDown_ValueChanged;
            // 
            // udDNM
            // 
            udDNM.DecimalPlaces = 2;
            udDNM.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDNM.Location = new Point(177, 152);
            udDNM.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDNM.Name = "udDNM";
            udDNM.Size = new Size(53, 23);
            udDNM.TabIndex = 133;
            udDNM.ValueChanged += UpDown_ValueChanged;
            // 
            // udDNS
            // 
            udDNS.DecimalPlaces = 2;
            udDNS.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDNS.Location = new Point(177, 127);
            udDNS.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDNS.Name = "udDNS";
            udDNS.Size = new Size(53, 23);
            udDNS.TabIndex = 132;
            udDNS.ValueChanged += UpDown_ValueChanged;
            // 
            // udDZE
            // 
            udDZE.DecimalPlaces = 2;
            udDZE.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDZE.Location = new Point(177, 102);
            udDZE.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDZE.Name = "udDZE";
            udDZE.Size = new Size(53, 23);
            udDZE.TabIndex = 131;
            udDZE.ValueChanged += UpDown_ValueChanged;
            // 
            // udDPS
            // 
            udDPS.DecimalPlaces = 2;
            udDPS.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDPS.Location = new Point(177, 77);
            udDPS.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDPS.Name = "udDPS";
            udDPS.Size = new Size(53, 23);
            udDPS.TabIndex = 129;
            udDPS.ValueChanged += UpDown_ValueChanged;
            // 
            // udDPM
            // 
            udDPM.DecimalPlaces = 2;
            udDPM.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDPM.Location = new Point(177, 52);
            udDPM.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDPM.Name = "udDPM";
            udDPM.Size = new Size(53, 23);
            udDPM.TabIndex = 130;
            udDPM.ValueChanged += UpDown_ValueChanged;
            // 
            // udDPL
            // 
            udDPL.DecimalPlaces = 2;
            udDPL.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udDPL.Location = new Point(177, 27);
            udDPL.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udDPL.Name = "udDPL";
            udDPL.Size = new Size(53, 23);
            udDPL.TabIndex = 128;
            udDPL.ValueChanged += UpDown_ValueChanged;
            // 
            // udENL
            // 
            udENL.DecimalPlaces = 2;
            udENL.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udENL.Location = new Point(48, 177);
            udENL.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udENL.Name = "udENL";
            udENL.Size = new Size(53, 23);
            udENL.TabIndex = 127;
            udENL.ValueChanged += UpDown_ValueChanged;
            // 
            // udENM
            // 
            udENM.DecimalPlaces = 2;
            udENM.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udENM.Location = new Point(48, 152);
            udENM.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udENM.Name = "udENM";
            udENM.Size = new Size(53, 23);
            udENM.TabIndex = 126;
            udENM.ValueChanged += UpDown_ValueChanged;
            // 
            // udENS
            // 
            udENS.DecimalPlaces = 2;
            udENS.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udENS.Location = new Point(48, 127);
            udENS.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udENS.Name = "udENS";
            udENS.Size = new Size(53, 23);
            udENS.TabIndex = 125;
            udENS.ValueChanged += UpDown_ValueChanged;
            // 
            // udEZE
            // 
            udEZE.DecimalPlaces = 2;
            udEZE.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udEZE.Location = new Point(48, 102);
            udEZE.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udEZE.Name = "udEZE";
            udEZE.Size = new Size(53, 23);
            udEZE.TabIndex = 124;
            udEZE.ValueChanged += UpDown_ValueChanged;
            // 
            // udEPS
            // 
            udEPS.DecimalPlaces = 2;
            udEPS.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udEPS.Location = new Point(48, 77);
            udEPS.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udEPS.Name = "udEPS";
            udEPS.Size = new Size(53, 23);
            udEPS.TabIndex = 123;
            udEPS.ValueChanged += UpDown_ValueChanged;
            // 
            // udEPM
            // 
            udEPM.DecimalPlaces = 2;
            udEPM.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udEPM.Location = new Point(48, 52);
            udEPM.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udEPM.Name = "udEPM";
            udEPM.Size = new Size(53, 23);
            udEPM.TabIndex = 123;
            udEPM.ValueChanged += UpDown_ValueChanged;
            // 
            // udEPL
            // 
            udEPL.DecimalPlaces = 2;
            udEPL.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            udEPL.Location = new Point(48, 27);
            udEPL.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            udEPL.Name = "udEPL";
            udEPL.Size = new Size(53, 23);
            udEPL.TabIndex = 122;
            udEPL.ValueChanged += UpDown_ValueChanged;
            // 
            // lblDPL
            // 
            lblDPL.AutoSize = true;
            lblDPL.Location = new Point(136, 29);
            lblDPL.Name = "lblDPL";
            lblDPL.Size = new Size(35, 15);
            lblDPL.TabIndex = 115;
            lblDPL.Text = "d_PL:";
            // 
            // lblDPM
            // 
            lblDPM.AutoSize = true;
            lblDPM.Location = new Point(131, 54);
            lblDPM.Name = "lblDPM";
            lblDPM.Size = new Size(40, 15);
            lblDPM.TabIndex = 116;
            lblDPM.Text = "d_PM:";
            // 
            // lblDPS
            // 
            lblDPS.AutoSize = true;
            lblDPS.Location = new Point(136, 79);
            lblDPS.Name = "lblDPS";
            lblDPS.Size = new Size(35, 15);
            lblDPS.TabIndex = 117;
            lblDPS.Text = "d_PS:";
            // 
            // lblDNL
            // 
            lblDNL.AutoSize = true;
            lblDNL.Location = new Point(134, 179);
            lblDNL.Name = "lblDNL";
            lblDNL.Size = new Size(37, 15);
            lblDNL.TabIndex = 121;
            lblDNL.Text = "d_NL:";
            // 
            // lblDZE
            // 
            lblDZE.AutoSize = true;
            lblDZE.Location = new Point(136, 103);
            lblDZE.Name = "lblDZE";
            lblDZE.Size = new Size(35, 15);
            lblDZE.TabIndex = 118;
            lblDZE.Text = "d_ZE:";
            // 
            // lblDNM
            // 
            lblDNM.AutoSize = true;
            lblDNM.Location = new Point(129, 154);
            lblDNM.Name = "lblDNM";
            lblDNM.Size = new Size(42, 15);
            lblDNM.TabIndex = 120;
            lblDNM.Text = "d_NM:";
            // 
            // lblDNS
            // 
            lblDNS.AutoSize = true;
            lblDNS.Location = new Point(134, 129);
            lblDNS.Name = "lblDNS";
            lblDNS.Size = new Size(37, 15);
            lblDNS.TabIndex = 119;
            lblDNS.Text = "d_NS:";
            // 
            // lblENS
            // 
            lblENS.AutoSize = true;
            lblENS.Location = new Point(10, 129);
            lblENS.Name = "lblENS";
            lblENS.Size = new Size(36, 15);
            lblENS.TabIndex = 102;
            lblENS.Text = "E_NS:";
            // 
            // btnApplyEDWeights
            // 
            btnApplyEDWeights.Enabled = false;
            btnApplyEDWeights.Location = new Point(45, 207);
            btnApplyEDWeights.Name = "btnApplyEDWeights";
            btnApplyEDWeights.Size = new Size(169, 23);
            btnApplyEDWeights.TabIndex = 95;
            btnApplyEDWeights.Text = "Apply Changes";
            btnApplyEDWeights.UseVisualStyleBackColor = true;
            // 
            // lblENM
            // 
            lblENM.AutoSize = true;
            lblENM.Location = new Point(5, 154);
            lblENM.Name = "lblENM";
            lblENM.Size = new Size(41, 15);
            lblENM.TabIndex = 103;
            lblENM.Text = "E_NM:";
            // 
            // lblEZE
            // 
            lblEZE.AutoSize = true;
            lblEZE.Location = new Point(12, 103);
            lblEZE.Name = "lblEZE";
            lblEZE.Size = new Size(34, 15);
            lblEZE.TabIndex = 101;
            lblEZE.Text = "E_ZE:";
            // 
            // lblENL
            // 
            lblENL.AutoSize = true;
            lblENL.Location = new Point(10, 179);
            lblENL.Name = "lblENL";
            lblENL.Size = new Size(36, 15);
            lblENL.TabIndex = 104;
            lblENL.Text = "E_NL:";
            // 
            // lblEPS
            // 
            lblEPS.AutoSize = true;
            lblEPS.Location = new Point(12, 79);
            lblEPS.Name = "lblEPS";
            lblEPS.Size = new Size(34, 15);
            lblEPS.TabIndex = 100;
            lblEPS.Text = "E_PS:";
            // 
            // lblEPM
            // 
            lblEPM.AutoSize = true;
            lblEPM.Location = new Point(7, 54);
            lblEPM.Name = "lblEPM";
            lblEPM.Size = new Size(39, 15);
            lblEPM.TabIndex = 99;
            lblEPM.Text = "E_PM:";
            // 
            // lblEPL
            // 
            lblEPL.AutoSize = true;
            lblEPL.Location = new Point(12, 29);
            lblEPL.Name = "lblEPL";
            lblEPL.Size = new Size(34, 15);
            lblEPL.TabIndex = 98;
            lblEPL.Text = "E_PL:";
            // 
            // Fuzzy_X_Weights
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 291);
            Controls.Add(gbXGridValues);
            Name = "Fuzzy_X_Weights";
            Text = "Fuzzy_X_Weights";
            gbXGridValues.ResumeLayout(false);
            gbXGridValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)udDNL).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDNM).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDNS).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDZE).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDPS).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDPM).EndInit();
            ((System.ComponentModel.ISupportInitialize)udDPL).EndInit();
            ((System.ComponentModel.ISupportInitialize)udENL).EndInit();
            ((System.ComponentModel.ISupportInitialize)udENM).EndInit();
            ((System.ComponentModel.ISupportInitialize)udENS).EndInit();
            ((System.ComponentModel.ISupportInitialize)udEZE).EndInit();
            ((System.ComponentModel.ISupportInitialize)udEPS).EndInit();
            ((System.ComponentModel.ISupportInitialize)udEPM).EndInit();
            ((System.ComponentModel.ISupportInitialize)udEPL).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbXGridValues;
        private NumericUpDown udDNL;
        private NumericUpDown udDNM;
        private NumericUpDown udDNS;
        private NumericUpDown udDZE;
        private NumericUpDown udDPS;
        private NumericUpDown udDPM;
        private NumericUpDown udDPL;
        private NumericUpDown udENL;
        private NumericUpDown udENM;
        private NumericUpDown udENS;
        private NumericUpDown udEZE;
        private NumericUpDown udEPS;
        private NumericUpDown udEPM;
        private NumericUpDown udEPL;
        private Label lblDPL;
        private Label lblDPM;
        private Label lblDPS;
        private Label lblDNL;
        private Label lblDZE;
        private Label lblDNM;
        private Label lblDNS;
        private Label lblENS;
        private Button btnApplyEDWeights;
        private Label lblENM;
        private Label lblEZE;
        private Label lblENL;
        private Label lblEPS;
        private Label lblEPM;
        private Label lblEPL;
        private Button btnClose;
    }
}