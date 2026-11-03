namespace Fuzzy_Tool
{
    partial class Fuzzy_Turtle_Data_Form
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
            cmbTurtleCommands = new ComboBox();
            btnClose = new Button();
            lblTurtleCommand = new Label();
            txtTurtleCommand = new TextBox();
            lblTurtleSelection = new Label();
            btnExecuteCommands = new Button();
            btnAddAnother = new Button();
            SuspendLayout();
            // 
            // cmbTurtleCommands
            // 
            cmbTurtleCommands.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTurtleCommands.FormattingEnabled = true;
            cmbTurtleCommands.Location = new Point(116, 8);
            cmbTurtleCommands.Name = "cmbTurtleCommands";
            cmbTurtleCommands.Size = new Size(157, 23);
            cmbTurtleCommands.TabIndex = 0;
            cmbTurtleCommands.SelectedIndexChanged += cmbTurtleCommands_SelectedIndexChanged;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(198, 170);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTurtleCommand
            // 
            lblTurtleCommand.AutoSize = true;
            lblTurtleCommand.Location = new Point(11, 42);
            lblTurtleCommand.Name = "lblTurtleCommand";
            lblTurtleCommand.Size = new Size(101, 15);
            lblTurtleCommand.TabIndex = 21;
            lblTurtleCommand.Text = "Turtle Command:";
            // 
            // txtTurtleCommand
            // 
            txtTurtleCommand.BackColor = Color.White;
            txtTurtleCommand.Location = new Point(12, 60);
            txtTurtleCommand.Multiline = true;
            txtTurtleCommand.Name = "txtTurtleCommand";
            txtTurtleCommand.ReadOnly = true;
            txtTurtleCommand.Size = new Size(261, 104);
            txtTurtleCommand.TabIndex = 19;
            txtTurtleCommand.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTurtleSelection
            // 
            lblTurtleSelection.AutoSize = true;
            lblTurtleSelection.Location = new Point(49, 16);
            lblTurtleSelection.Name = "lblTurtleSelection";
            lblTurtleSelection.Size = new Size(58, 15);
            lblTurtleSelection.TabIndex = 22;
            lblTurtleSelection.Text = "Selection:";
            // 
            // btnExecuteCommands
            // 
            btnExecuteCommands.Location = new Point(49, 170);
            btnExecuteCommands.Name = "btnExecuteCommands";
            btnExecuteCommands.Size = new Size(142, 23);
            btnExecuteCommands.TabIndex = 23;
            btnExecuteCommands.Text = "Execute Commands";
            btnExecuteCommands.UseVisualStyleBackColor = true;
            btnExecuteCommands.Click += btnExecuteCommands_Click;
            // 
            // btnAddAnother
            // 
            btnAddAnother.Location = new Point(133, 32);
            btnAddAnother.Name = "btnAddAnother";
            btnAddAnother.Size = new Size(140, 23);
            btnAddAnother.TabIndex = 24;
            btnAddAnother.Text = "Add Same Command";
            btnAddAnother.UseVisualStyleBackColor = true;
            btnAddAnother.Click += btnAddAnother_Click;
            // 
            // Fuzzy_Turtle_Data_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 205);
            ControlBox = false;
            Controls.Add(btnAddAnother);
            Controls.Add(btnExecuteCommands);
            Controls.Add(lblTurtleSelection);
            Controls.Add(lblTurtleCommand);
            Controls.Add(txtTurtleCommand);
            Controls.Add(btnClose);
            Controls.Add(cmbTurtleCommands);
            Name = "Fuzzy_Turtle_Data_Form";
            Text = "Fuzzy_Turtle_Data_Form";
            Load += Fuzzy_Turtle_Data_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTurtleCommands;
        private Button btnClose;
        private Label lblTurtleCommand;
        private TextBox txtTurtleCommand;
        private Label lblTurtleSelection;
        private Button btnExecuteCommands;
        private Button btnAddAnother;
    }
}