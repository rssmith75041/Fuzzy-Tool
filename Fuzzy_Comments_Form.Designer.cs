namespace Fuzzy_Tool
{
    partial class Fuzzy_Comments_Form
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
            btnClear = new Button();
            btnCancel = new Button();
            btnOk = new Button();
            txtComments = new TextBox();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Location = new Point(9, 395);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(90, 395);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(171, 395);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtComments
            // 
            txtComments.Location = new Point(8, 27);
            txtComments.Multiline = true;
            txtComments.Name = "txtComments";
            txtComments.ScrollBars = ScrollBars.Both;
            txtComments.Size = new Size(780, 362);
            txtComments.TabIndex = 3;
            // 
            // Fuzzy_Comments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            ControlBox = false;
            Controls.Add(txtComments);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Name = "Fuzzy_Comments";
            Text = "Fuzzy Comments";
            Load += Fuzzy_Comments_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClear;
        private Button btnCancel;
        private Button btnOk;
        private TextBox txtComments;
    }
}