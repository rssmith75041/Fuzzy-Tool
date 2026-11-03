namespace Fuzzy_Tool
{
    partial class Fuzzy_Control_Form
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
            ckbDisplayFiring = new CheckBox();
            ckbDisplayGraph = new CheckBox();
            btnNoise = new Button();
            btnStep = new Button();
            btnResume = new Button();
            btnStop = new Button();
            btnPause = new Button();
            btnExecute = new Button();
            btnClose = new Button();
            btnRefresh = new Button();
            pnlGraph = new Panel();
            ckbXVelocityAsDError = new CheckBox();
            ckbAutoX = new CheckBox();
            ckbAutoD = new CheckBox();
            ckbDrawingStyle = new CheckBox();
            ckbDisplayFuzzyWeights = new CheckBox();
            ckbLegacyVSMamdami = new CheckBox();
            btnFuzzyWorkspaceForm = new Button();
            lblCurrentMode = new Label();
            lblWhichParser = new Label();
            pnlGraphMeasure = new Panel();
            SuspendLayout();
            // 
            // ckbDisplayFiring
            // 
            ckbDisplayFiring.AutoSize = true;
            ckbDisplayFiring.Checked = true;
            ckbDisplayFiring.CheckState = CheckState.Checked;
            ckbDisplayFiring.Location = new Point(895, 694);
            ckbDisplayFiring.Name = "ckbDisplayFiring";
            ckbDisplayFiring.Size = new Size(97, 19);
            ckbDisplayFiring.TabIndex = 1;
            ckbDisplayFiring.Text = "Display Firing";
            ckbDisplayFiring.UseVisualStyleBackColor = true;
            ckbDisplayFiring.CheckedChanged += ckbDisplayFiring_CheckedChanged;
            // 
            // ckbDisplayGraph
            // 
            ckbDisplayGraph.AutoSize = true;
            ckbDisplayGraph.Location = new Point(660, 694);
            ckbDisplayGraph.Name = "ckbDisplayGraph";
            ckbDisplayGraph.Size = new Size(99, 19);
            ckbDisplayGraph.TabIndex = 2;
            ckbDisplayGraph.Text = "Display Graph";
            ckbDisplayGraph.UseVisualStyleBackColor = true;
            ckbDisplayGraph.CheckedChanged += ckbDisplayGraph_CheckedChanged;
            // 
            // btnNoise
            // 
            btnNoise.Location = new Point(579, 696);
            btnNoise.Name = "btnNoise";
            btnNoise.Size = new Size(75, 23);
            btnNoise.TabIndex = 4;
            btnNoise.Text = "Noise";
            btnNoise.UseVisualStyleBackColor = true;
            btnNoise.Click += btnNoise_Click;
            // 
            // btnStep
            // 
            btnStep.Location = new Point(12, 696);
            btnStep.Name = "btnStep";
            btnStep.Size = new Size(75, 23);
            btnStep.TabIndex = 5;
            btnStep.Text = "Step";
            btnStep.UseVisualStyleBackColor = true;
            btnStep.Click += btnStep_Click;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(93, 696);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(75, 23);
            btnResume.TabIndex = 6;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(174, 696);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(255, 696);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 8;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(336, 696);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(75, 23);
            btnExecute.TabIndex = 9;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(417, 696);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(498, 696);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlGraph
            // 
            pnlGraph.AutoScroll = true;
            pnlGraph.AutoScrollMinSize = new Size(2000, 510);
            pnlGraph.Location = new Point(50, 9);
            pnlGraph.Name = "pnlGraph";
            pnlGraph.Size = new Size(1267, 679);
            pnlGraph.TabIndex = 12;
            // 
            // ckbXVelocityAsDError
            // 
            ckbXVelocityAsDError.AutoSize = true;
            ckbXVelocityAsDError.Location = new Point(763, 694);
            ckbXVelocityAsDError.Name = "ckbXVelocityAsDError";
            ckbXVelocityAsDError.Size = new Size(126, 19);
            ckbXVelocityAsDError.TabIndex = 13;
            ckbXVelocityAsDError.Text = "X Velocity as dError";
            ckbXVelocityAsDError.UseVisualStyleBackColor = true;
            // 
            // ckbAutoX
            // 
            ckbAutoX.AutoSize = true;
            ckbAutoX.Location = new Point(763, 719);
            ckbAutoX.Name = "ckbAutoX";
            ckbAutoX.Size = new Size(62, 19);
            ckbAutoX.TabIndex = 15;
            ckbAutoX.Text = "Auto X";
            ckbAutoX.TextAlign = ContentAlignment.TopLeft;
            ckbAutoX.UseVisualStyleBackColor = true;
            ckbAutoX.CheckedChanged += ckbAutoX_CheckedChanged;
            // 
            // ckbAutoD
            // 
            ckbAutoD.AutoSize = true;
            ckbAutoD.Location = new Point(826, 719);
            ckbAutoD.Name = "ckbAutoD";
            ckbAutoD.Size = new Size(63, 19);
            ckbAutoD.TabIndex = 16;
            ckbAutoD.Text = "Auto D";
            ckbAutoD.TextAlign = ContentAlignment.TopLeft;
            ckbAutoD.UseVisualStyleBackColor = true;
            ckbAutoD.CheckedChanged += ckbAutoD_CheckedChanged;
            // 
            // ckbDrawingStyle
            // 
            ckbDrawingStyle.AutoSize = true;
            ckbDrawingStyle.Location = new Point(660, 719);
            ckbDrawingStyle.Name = "ckbDrawingStyle";
            ckbDrawingStyle.Size = new Size(95, 19);
            ckbDrawingStyle.TabIndex = 17;
            ckbDrawingStyle.Text = "Line Drawing";
            ckbDrawingStyle.UseVisualStyleBackColor = true;
            ckbDrawingStyle.CheckedChanged += ckbDrawingStyle_CheckedChanged;
            // 
            // ckbDisplayFuzzyWeights
            // 
            ckbDisplayFuzzyWeights.AutoSize = true;
            ckbDisplayFuzzyWeights.Location = new Point(895, 719);
            ckbDisplayFuzzyWeights.Name = "ckbDisplayFuzzyWeights";
            ckbDisplayFuzzyWeights.Size = new Size(142, 19);
            ckbDisplayFuzzyWeights.TabIndex = 18;
            ckbDisplayFuzzyWeights.Text = "Display Fuzzy Weights";
            ckbDisplayFuzzyWeights.TextAlign = ContentAlignment.TopLeft;
            ckbDisplayFuzzyWeights.UseVisualStyleBackColor = true;
            ckbDisplayFuzzyWeights.CheckedChanged += ckbDisplayFuzzyWeights_CheckedChanged;
            // 
            // ckbLegacyVSMamdami
            // 
            ckbLegacyVSMamdami.AutoSize = true;
            ckbLegacyVSMamdami.Location = new Point(201, 722);
            ckbLegacyVSMamdami.Name = "ckbLegacyVSMamdami";
            ckbLegacyVSMamdami.Size = new Size(135, 19);
            ckbLegacyVSMamdami.TabIndex = 19;
            ckbLegacyVSMamdami.Text = "Use Mamdami Fuzzy";
            ckbLegacyVSMamdami.TextAlign = ContentAlignment.TopLeft;
            ckbLegacyVSMamdami.UseVisualStyleBackColor = true;
            ckbLegacyVSMamdami.CheckedChanged += ckbLegacyVSMamdami_CheckedChanged;
            // 
            // btnFuzzyWorkspaceForm
            // 
            btnFuzzyWorkspaceForm.Enabled = false;
            btnFuzzyWorkspaceForm.Location = new Point(467, 720);
            btnFuzzyWorkspaceForm.Name = "btnFuzzyWorkspaceForm";
            btnFuzzyWorkspaceForm.Size = new Size(187, 23);
            btnFuzzyWorkspaceForm.TabIndex = 20;
            btnFuzzyWorkspaceForm.Text = "Open Fuzzy Workspace Form";
            btnFuzzyWorkspaceForm.UseVisualStyleBackColor = true;
            btnFuzzyWorkspaceForm.Click += btnFuzzyWorkspaceForm_Click;
            // 
            // lblCurrentMode
            // 
            lblCurrentMode.AutoSize = true;
            lblCurrentMode.Location = new Point(342, 724);
            lblCurrentMode.Name = "lblCurrentMode";
            lblCurrentMode.Size = new Size(109, 15);
            lblCurrentMode.TabIndex = 21;
            lblCurrentMode.Text = "Using Legacy Fuzzy";
            // 
            // lblWhichParser
            // 
            lblWhichParser.AutoSize = true;
            lblWhichParser.Location = new Point(12, 725);
            lblWhichParser.Name = "lblWhichParser";
            lblWhichParser.Size = new Size(42, 15);
            lblWhichParser.TabIndex = 22;
            lblWhichParser.Text = "Parser:";
            // 
            // pnlGraphMeasure
            // 
            pnlGraphMeasure.BackColor = Color.Black;
            pnlGraphMeasure.Location = new Point(11, 9);
            pnlGraphMeasure.Name = "pnlGraphMeasure";
            pnlGraphMeasure.Size = new Size(40, 662);
            pnlGraphMeasure.TabIndex = 23;
            pnlGraphMeasure.Paint += pnlGraphMeasure_Paint;
            // 
            // Fuzzy_Control_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 755);
            ControlBox = false;
            Controls.Add(pnlGraphMeasure);
            Controls.Add(lblWhichParser);
            Controls.Add(lblCurrentMode);
            Controls.Add(btnFuzzyWorkspaceForm);
            Controls.Add(ckbLegacyVSMamdami);
            Controls.Add(ckbDisplayFuzzyWeights);
            Controls.Add(ckbDrawingStyle);
            Controls.Add(ckbAutoD);
            Controls.Add(ckbAutoX);
            Controls.Add(ckbXVelocityAsDError);
            Controls.Add(pnlGraph);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(btnExecute);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(btnResume);
            Controls.Add(btnStep);
            Controls.Add(btnNoise);
            Controls.Add(ckbDisplayGraph);
            Controls.Add(ckbDisplayFiring);
            Name = "Fuzzy_Control_Form";
            Text = "Fuzzy Control";
            FormClosing += Fuzzy_Control_FormClosing;
            Load += Fuzzy_Control_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox ckbDisplayFiring;
        private CheckBox ckbDisplayGraph;
        private Button btnNoise;
        private Button btnStep;
        private Button btnResume;
        private Button btnStop;
        private Button btnPause;
        private Button btnExecute;
        private Button btnClose;
        private Button btnRefresh;
        private Panel pnlGraph;
        private CheckBox ckbXVelocityAsDError;
        private CheckBox ckbAutoX;
        private CheckBox ckbAutoD;
        private CheckBox ckbDrawingStyle;
        private CheckBox ckbDisplayFuzzyWeights;
        private CheckBox ckbLegacyVSMamdami;
        private Button btnFuzzyWorkspaceForm;
        private Label lblCurrentMode;
        private Label lblWhichParser;
        private Panel pnlGraphMeasure;
    }
}