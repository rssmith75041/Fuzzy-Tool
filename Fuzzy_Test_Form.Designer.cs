namespace Fuzzy_Tool
{
    partial class Fuzzy_Test_Form
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
            btnExecute = new Button();
            txtEquation = new TextBox();
            gbSystem = new GroupBox();
            rbModern = new RadioButton();
            rbLegacy = new RadioButton();
            lblEquation = new Label();
            lblAnswer = new Label();
            txtAnswer = new TextBox();
            txtError = new TextBox();
            lblError = new Label();
            btnClose = new Button();
            gbSystem.SuspendLayout();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(404, 12);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(75, 23);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Evaluate";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnCommand_Click;
            // 
            // txtEquation
            // 
            txtEquation.BackColor = Color.White;
            txtEquation.Location = new Point(70, 11);
            txtEquation.Name = "txtEquation";
            txtEquation.Size = new Size(328, 23);
            txtEquation.TabIndex = 1;
            // 
            // gbSystem
            // 
            gbSystem.Controls.Add(rbModern);
            gbSystem.Controls.Add(rbLegacy);
            gbSystem.Location = new Point(485, 15);
            gbSystem.Name = "gbSystem";
            gbSystem.Size = new Size(116, 82);
            gbSystem.TabIndex = 2;
            gbSystem.TabStop = false;
            gbSystem.Text = "Execution System";
            // 
            // rbModern
            // 
            rbModern.AutoSize = true;
            rbModern.Location = new Point(11, 48);
            rbModern.Name = "rbModern";
            rbModern.Size = new Size(67, 19);
            rbModern.TabIndex = 1;
            rbModern.Text = "Modern";
            rbModern.UseVisualStyleBackColor = true;
            // 
            // rbLegacy
            // 
            rbLegacy.AutoSize = true;
            rbLegacy.Checked = true;
            rbLegacy.Location = new Point(11, 23);
            rbLegacy.Name = "rbLegacy";
            rbLegacy.Size = new Size(62, 19);
            rbLegacy.TabIndex = 0;
            rbLegacy.TabStop = true;
            rbLegacy.Text = "Legacy";
            rbLegacy.UseVisualStyleBackColor = true;
            // 
            // lblEquation
            // 
            lblEquation.AutoSize = true;
            lblEquation.Location = new Point(14, 15);
            lblEquation.Name = "lblEquation";
            lblEquation.Size = new Size(57, 15);
            lblEquation.TabIndex = 3;
            lblEquation.Text = "Equation:";
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Location = new Point(14, 49);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(46, 15);
            lblAnswer.TabIndex = 4;
            lblAnswer.Text = "Answer";
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.White;
            txtAnswer.Location = new Point(70, 43);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ReadOnly = true;
            txtAnswer.Size = new Size(146, 23);
            txtAnswer.TabIndex = 5;
            // 
            // txtError
            // 
            txtError.BackColor = Color.White;
            txtError.Location = new Point(70, 74);
            txtError.Name = "txtError";
            txtError.ReadOnly = true;
            txtError.Size = new Size(328, 23);
            txtError.TabIndex = 7;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(14, 78);
            lblError.Name = "lblError";
            lblError.Size = new Size(32, 15);
            lblError.TabIndex = 6;
            lblError.Text = "Error";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(404, 73);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Fuzzy_Test_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 109);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(txtError);
            Controls.Add(lblError);
            Controls.Add(txtAnswer);
            Controls.Add(lblAnswer);
            Controls.Add(lblEquation);
            Controls.Add(gbSystem);
            Controls.Add(txtEquation);
            Controls.Add(btnExecute);
            Name = "Fuzzy_Test_Form";
            Text = "Fuzzy Test Form";
            gbSystem.ResumeLayout(false);
            gbSystem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExecute;
        private TextBox txtEquation;
        private GroupBox gbSystem;
        private Label lblEquation;
        private RadioButton rbModern;
        private RadioButton rbLegacy;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private TextBox txtError;
        private Label lblError;
        private Button btnClose;
    }
}