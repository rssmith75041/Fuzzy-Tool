namespace Fuzzy_Tool
{
    partial class TestParserForm
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
            lblEquation = new Label();
            txtEquation = new TextBox();
            btnTestParser = new Button();
            lblAnswer = new Label();
            txtAnswer = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblEquation
            // 
            lblEquation.AutoSize = true;
            lblEquation.Location = new Point(13, 13);
            lblEquation.Name = "lblEquation";
            lblEquation.Size = new Size(57, 15);
            lblEquation.TabIndex = 0;
            lblEquation.Text = "Equation:";
            // 
            // txtEquation
            // 
            txtEquation.Location = new Point(68, 10);
            txtEquation.Name = "txtEquation";
            txtEquation.Size = new Size(378, 23);
            txtEquation.TabIndex = 1;
            // 
            // btnTestParser
            // 
            btnTestParser.Location = new Point(13, 42);
            btnTestParser.Name = "btnTestParser";
            btnTestParser.Size = new Size(75, 23);
            btnTestParser.TabIndex = 2;
            btnTestParser.Text = "Evaluate";
            btnTestParser.UseVisualStyleBackColor = true;
            btnTestParser.Click += btnTestParser_Click;
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Location = new Point(97, 44);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(49, 15);
            lblAnswer.TabIndex = 3;
            lblAnswer.Text = "Answer:";
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.White;
            txtAnswer.Location = new Point(147, 41);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ReadOnly = true;
            txtAnswer.Size = new Size(134, 23);
            txtAnswer.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(371, 42);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.TabStop = false;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // TestParserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 88);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(txtAnswer);
            Controls.Add(lblAnswer);
            Controls.Add(btnTestParser);
            Controls.Add(txtEquation);
            Controls.Add(lblEquation);
            Name = "TestParserForm";
            Text = "Test Parser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEquation;
        private TextBox txtEquation;
        private Button btnTestParser;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private Button btnClose;
    }
}