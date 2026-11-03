namespace Fuzzy_Tool
{
    partial class Fuzzy_WorkSpace_Form
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
            cmbVariable = new ComboBox();
            lblVariable = new Label();
            lstRules = new ListBox();
            lblRules = new Label();
            lblSets = new Label();
            lstSets = new ListBox();
            lblName = new Label();
            txtName = new TextBox();
            lblShape = new Label();
            cmbShape = new ComboBox();
            numA = new NumericUpDown();
            numD = new NumericUpDown();
            numC = new NumericUpDown();
            numB = new NumericUpDown();
            lblNumA = new Label();
            lblNumD = new Label();
            lblNumC = new Label();
            lblNumB = new Label();
            pbPreview = new PictureBox();
            btnAddSet = new Button();
            btnDeleteSet = new Button();
            btnDeleteRule = new Button();
            btnAddRule = new Button();
            cmbErrorSet = new ComboBox();
            lblThen = new Label();
            cmbOutputSet = new ComboBox();
            cmbDErrorSet = new ComboBox();
            lblSaveCurrentSet = new Button();
            btnApply = new Button();
            lblIf = new Label();
            lblAnd = new Label();
            btnGenerate5StandardSets = new Button();
            btnGenerateRules = new Button();
            dgvRuleMatrix = new DataGridView();
            lblPreview = new Label();
            lbldError = new Label();
            lblErrorE = new Label();
            lblErrorr1 = new Label();
            lblError = new Label();
            label1lblErrorr3 = new Label();
            lblErrorr2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRuleMatrix).BeginInit();
            SuspendLayout();
            // 
            // cmbVariable
            // 
            cmbVariable.FormattingEnabled = true;
            cmbVariable.Location = new Point(64, 13);
            cmbVariable.Name = "cmbVariable";
            cmbVariable.Size = new Size(121, 23);
            cmbVariable.TabIndex = 0;
            cmbVariable.SelectedIndexChanged += cmbVariable_SelectedIndexChanged;
            // 
            // lblVariable
            // 
            lblVariable.AutoSize = true;
            lblVariable.Location = new Point(13, 17);
            lblVariable.Name = "lblVariable";
            lblVariable.Size = new Size(48, 15);
            lblVariable.TabIndex = 1;
            lblVariable.Text = "Variable";
            // 
            // lstRules
            // 
            lstRules.FormattingEnabled = true;
            lstRules.ItemHeight = 15;
            lstRules.Location = new Point(64, 206);
            lstRules.Name = "lstRules";
            lstRules.Size = new Size(434, 154);
            lstRules.TabIndex = 2;
            // 
            // lblRules
            // 
            lblRules.AutoSize = true;
            lblRules.Location = new Point(26, 206);
            lblRules.Name = "lblRules";
            lblRules.Size = new Size(35, 15);
            lblRules.TabIndex = 3;
            lblRules.Text = "Rules";
            // 
            // lblSets
            // 
            lblSets.AutoSize = true;
            lblSets.Location = new Point(33, 52);
            lblSets.Name = "lblSets";
            lblSets.Size = new Size(28, 15);
            lblSets.TabIndex = 5;
            lblSets.Text = "Sets";
            // 
            // lstSets
            // 
            lstSets.FormattingEnabled = true;
            lstSets.ItemHeight = 15;
            lstSets.Location = new Point(64, 44);
            lstSets.Name = "lstSets";
            lstSets.Size = new Size(434, 79);
            lstSets.TabIndex = 4;
            lstSets.SelectedIndexChanged += lstSets_SelectedIndexChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(198, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 6;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(244, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 7;
            txtName.TextChanged += AnySetValueChanged;
            // 
            // lblShape
            // 
            lblShape.AutoSize = true;
            lblShape.Location = new Point(357, 16);
            lblShape.Name = "lblShape";
            lblShape.Size = new Size(39, 15);
            lblShape.TabIndex = 9;
            lblShape.Text = "Shape";
            // 
            // cmbShape
            // 
            cmbShape.FormattingEnabled = true;
            cmbShape.Items.AddRange(new object[] { "Triangle", "Trapezoid" });
            cmbShape.Location = new Point(411, 12);
            cmbShape.Name = "cmbShape";
            cmbShape.Size = new Size(87, 23);
            cmbShape.TabIndex = 8;
            cmbShape.SelectedIndexChanged += AnySetValueChanged;
            // 
            // numA
            // 
            numA.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numA.Location = new Point(616, 15);
            numA.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numA.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numA.Name = "numA";
            numA.Size = new Size(77, 23);
            numA.TabIndex = 10;
            numA.ValueChanged += AnySetValueChanged;
            // 
            // numD
            // 
            numD.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numD.Location = new Point(616, 104);
            numD.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numD.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numD.Name = "numD";
            numD.Size = new Size(77, 23);
            numD.TabIndex = 12;
            numD.ValueChanged += AnySetValueChanged;
            // 
            // numC
            // 
            numC.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numC.Location = new Point(616, 75);
            numC.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numC.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numC.Name = "numC";
            numC.Size = new Size(77, 23);
            numC.TabIndex = 13;
            numC.ValueChanged += AnySetValueChanged;
            // 
            // numB
            // 
            numB.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numB.Location = new Point(616, 45);
            numB.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numB.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numB.Name = "numB";
            numB.Size = new Size(77, 23);
            numB.TabIndex = 14;
            numB.ValueChanged += AnySetValueChanged;
            // 
            // lblNumA
            // 
            lblNumA.AutoSize = true;
            lblNumA.Location = new Point(548, 16);
            lblNumA.Name = "lblNumA";
            lblNumA.Size = new Size(65, 15);
            lblNumA.TabIndex = 15;
            lblNumA.Text = "Number A:";
            // 
            // lblNumD
            // 
            lblNumD.AutoSize = true;
            lblNumD.Location = new Point(548, 106);
            lblNumD.Name = "lblNumD";
            lblNumD.Size = new Size(65, 15);
            lblNumD.TabIndex = 16;
            lblNumD.Text = "Number D:";
            // 
            // lblNumC
            // 
            lblNumC.AutoSize = true;
            lblNumC.Location = new Point(548, 76);
            lblNumC.Name = "lblNumC";
            lblNumC.Size = new Size(65, 15);
            lblNumC.TabIndex = 17;
            lblNumC.Text = "Number C:";
            // 
            // lblNumB
            // 
            lblNumB.AutoSize = true;
            lblNumB.Location = new Point(549, 46);
            lblNumB.Name = "lblNumB";
            lblNumB.Size = new Size(64, 15);
            lblNumB.TabIndex = 18;
            lblNumB.Text = "Number B:";
            // 
            // pbPreview
            // 
            pbPreview.BackColor = Color.White;
            pbPreview.Location = new Point(12, 433);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(680, 186);
            pbPreview.TabIndex = 19;
            pbPreview.TabStop = false;
            pbPreview.Paint += pbPreview_Paint;
            // 
            // btnAddSet
            // 
            btnAddSet.Location = new Point(68, 128);
            btnAddSet.Name = "btnAddSet";
            btnAddSet.Size = new Size(75, 23);
            btnAddSet.TabIndex = 20;
            btnAddSet.Text = "Add Set";
            btnAddSet.UseVisualStyleBackColor = true;
            btnAddSet.Click += btnAddSet_Click;
            // 
            // btnDeleteSet
            // 
            btnDeleteSet.Location = new Point(145, 128);
            btnDeleteSet.Name = "btnDeleteSet";
            btnDeleteSet.Size = new Size(75, 23);
            btnDeleteSet.TabIndex = 21;
            btnDeleteSet.Text = "Delete Set";
            btnDeleteSet.UseVisualStyleBackColor = true;
            btnDeleteSet.Click += btnDeleteSet_Click;
            // 
            // btnDeleteRule
            // 
            btnDeleteRule.Location = new Point(145, 367);
            btnDeleteRule.Name = "btnDeleteRule";
            btnDeleteRule.Size = new Size(75, 23);
            btnDeleteRule.TabIndex = 23;
            btnDeleteRule.Text = "Delete Rule";
            btnDeleteRule.UseVisualStyleBackColor = true;
            btnDeleteRule.Click += btnDeleteRule_Click;
            // 
            // btnAddRule
            // 
            btnAddRule.Location = new Point(64, 367);
            btnAddRule.Name = "btnAddRule";
            btnAddRule.Size = new Size(75, 23);
            btnAddRule.TabIndex = 22;
            btnAddRule.Text = "Add Rule";
            btnAddRule.UseVisualStyleBackColor = true;
            btnAddRule.Click += btnAddRule_Click;
            // 
            // cmbErrorSet
            // 
            cmbErrorSet.FormattingEnabled = true;
            cmbErrorSet.Location = new Point(107, 171);
            cmbErrorSet.Name = "cmbErrorSet";
            cmbErrorSet.Size = new Size(63, 23);
            cmbErrorSet.TabIndex = 24;
            // 
            // lblThen
            // 
            lblThen.AutoSize = true;
            lblThen.Location = new Point(339, 175);
            lblThen.Name = "lblThen";
            lblThen.Size = new Size(90, 15);
            lblThen.TabIndex = 27;
            lblThen.Text = "THEN Output is";
            // 
            // cmbOutputSet
            // 
            cmbOutputSet.FormattingEnabled = true;
            cmbOutputSet.Location = new Point(435, 172);
            cmbOutputSet.Name = "cmbOutputSet";
            cmbOutputSet.Size = new Size(63, 23);
            cmbOutputSet.TabIndex = 26;
            // 
            // cmbDErrorSet
            // 
            cmbDErrorSet.FormattingEnabled = true;
            cmbDErrorSet.Location = new Point(254, 172);
            cmbDErrorSet.Name = "cmbDErrorSet";
            cmbDErrorSet.Size = new Size(63, 23);
            cmbDErrorSet.TabIndex = 28;
            // 
            // lblSaveCurrentSet
            // 
            lblSaveCurrentSet.Location = new Point(222, 128);
            lblSaveCurrentSet.Name = "lblSaveCurrentSet";
            lblSaveCurrentSet.Size = new Size(75, 23);
            lblSaveCurrentSet.TabIndex = 30;
            lblSaveCurrentSet.Text = "Save Set";
            lblSaveCurrentSet.UseVisualStyleBackColor = true;
            lblSaveCurrentSet.Click += lblSaveCurrentSet_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(550, 362);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(144, 23);
            btnApply.TabIndex = 31;
            btnApply.Text = "Apply Changes";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // lblIf
            // 
            lblIf.AutoSize = true;
            lblIf.Location = new Point(48, 175);
            lblIf.Name = "lblIf";
            lblIf.Size = new Size(55, 15);
            lblIf.TabIndex = 32;
            lblIf.Text = "IF Error is";
            // 
            // lblAnd
            // 
            lblAnd.AutoSize = true;
            lblAnd.Location = new Point(174, 175);
            lblAnd.Name = "lblAnd";
            lblAnd.Size = new Size(78, 15);
            lblAnd.TabIndex = 33;
            lblAnd.Text = "AND dError is";
            // 
            // btnGenerate5StandardSets
            // 
            btnGenerate5StandardSets.Location = new Point(299, 128);
            btnGenerate5StandardSets.Name = "btnGenerate5StandardSets";
            btnGenerate5StandardSets.Size = new Size(124, 23);
            btnGenerate5StandardSets.TabIndex = 34;
            btnGenerate5StandardSets.Text = "Generate 5 Sets - PD";
            btnGenerate5StandardSets.UseVisualStyleBackColor = true;
            btnGenerate5StandardSets.Click += btnGenerate5StandardSets_Click;
            // 
            // btnGenerateRules
            // 
            btnGenerateRules.Location = new Point(226, 366);
            btnGenerateRules.Name = "btnGenerateRules";
            btnGenerateRules.Size = new Size(118, 23);
            btnGenerateRules.TabIndex = 35;
            btnGenerateRules.Text = "Generate PD Rules";
            btnGenerateRules.UseVisualStyleBackColor = true;
            btnGenerateRules.Click += btnGenerateRules_Click;
            // 
            // dgvRuleMatrix
            // 
            dgvRuleMatrix.AllowUserToAddRows = false;
            dgvRuleMatrix.AllowUserToDeleteRows = false;
            dgvRuleMatrix.AllowUserToResizeColumns = false;
            dgvRuleMatrix.AllowUserToResizeRows = false;
            dgvRuleMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRuleMatrix.ColumnHeadersVisible = false;
            dgvRuleMatrix.Enabled = false;
            dgvRuleMatrix.Location = new Point(529, 193);
            dgvRuleMatrix.Name = "dgvRuleMatrix";
            dgvRuleMatrix.ReadOnly = true;
            dgvRuleMatrix.RowHeadersVisible = false;
            dgvRuleMatrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvRuleMatrix.ScrollBars = ScrollBars.None;
            dgvRuleMatrix.Size = new Size(200, 151);
            dgvRuleMatrix.TabIndex = 36;
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Location = new Point(13, 415);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(48, 15);
            lblPreview.TabIndex = 37;
            lblPreview.Text = "Preview";
            // 
            // lbldError
            // 
            lbldError.AutoSize = true;
            lbldError.Location = new Point(609, 175);
            lbldError.Name = "lbldError";
            lbldError.Size = new Size(39, 15);
            lbldError.TabIndex = 39;
            lbldError.Text = "dError";
            // 
            // lblErrorE
            // 
            lblErrorE.AutoSize = true;
            lblErrorE.Location = new Point(509, 240);
            lblErrorE.Name = "lblErrorE";
            lblErrorE.Size = new Size(13, 15);
            lblErrorE.TabIndex = 40;
            lblErrorE.Text = "E";
            // 
            // lblErrorr1
            // 
            lblErrorr1.AutoSize = true;
            lblErrorr1.Location = new Point(509, 256);
            lblErrorr1.Name = "lblErrorr1";
            lblErrorr1.Size = new Size(11, 15);
            lblErrorr1.TabIndex = 41;
            lblErrorr1.Text = "r";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(509, 286);
            lblError.Name = "lblError";
            lblError.Size = new Size(14, 15);
            lblError.TabIndex = 43;
            lblError.Text = "o";
            // 
            // label1lblErrorr3
            // 
            label1lblErrorr3.AutoSize = true;
            label1lblErrorr3.Location = new Point(509, 301);
            label1lblErrorr3.Name = "label1lblErrorr3";
            label1lblErrorr3.Size = new Size(11, 15);
            label1lblErrorr3.TabIndex = 45;
            label1lblErrorr3.Text = "r";
            // 
            // lblErrorr2
            // 
            lblErrorr2.AutoSize = true;
            lblErrorr2.Location = new Point(509, 271);
            lblErrorr2.Name = "lblErrorr2";
            lblErrorr2.Size = new Size(11, 15);
            lblErrorr2.TabIndex = 46;
            lblErrorr2.Text = "r";
            // 
            // Fuzzy_WorkSpace_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 635);
            Controls.Add(lblErrorr2);
            Controls.Add(label1lblErrorr3);
            Controls.Add(lblError);
            Controls.Add(lblErrorr1);
            Controls.Add(lblErrorE);
            Controls.Add(lbldError);
            Controls.Add(lblPreview);
            Controls.Add(dgvRuleMatrix);
            Controls.Add(btnGenerateRules);
            Controls.Add(btnGenerate5StandardSets);
            Controls.Add(lblAnd);
            Controls.Add(lblIf);
            Controls.Add(btnApply);
            Controls.Add(lblSaveCurrentSet);
            Controls.Add(cmbDErrorSet);
            Controls.Add(lblThen);
            Controls.Add(cmbOutputSet);
            Controls.Add(cmbErrorSet);
            Controls.Add(btnDeleteRule);
            Controls.Add(btnAddRule);
            Controls.Add(btnDeleteSet);
            Controls.Add(btnAddSet);
            Controls.Add(pbPreview);
            Controls.Add(lblNumB);
            Controls.Add(lblNumC);
            Controls.Add(lblNumD);
            Controls.Add(lblNumA);
            Controls.Add(numB);
            Controls.Add(numC);
            Controls.Add(numD);
            Controls.Add(numA);
            Controls.Add(lblShape);
            Controls.Add(cmbShape);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblSets);
            Controls.Add(lstSets);
            Controls.Add(lblRules);
            Controls.Add(lstRules);
            Controls.Add(lblVariable);
            Controls.Add(cmbVariable);
            Name = "Fuzzy_WorkSpace_Form";
            Text = "Fuzzy WorkSpace Form - Mamdami";
            ((System.ComponentModel.ISupportInitialize)numA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numD).EndInit();
            ((System.ComponentModel.ISupportInitialize)numC).EndInit();
            ((System.ComponentModel.ISupportInitialize)numB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRuleMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbVariable;
        private Label lblVariable;
        private ListBox lstRules;
        private Label lblRules;
        private Label lblSets;
        private ListBox lstSets;
        private Label lblName;
        private TextBox txtName;
        private Label lblShape;
        private ComboBox cmbShape;
        private NumericUpDown numA;
        private NumericUpDown numD;
        private NumericUpDown numC;
        private NumericUpDown numB;
        private Label lblNumA;
        private Label lblNumD;
        private Label lblNumC;
        private Label lblNumB;
        private PictureBox pbPreview;
        private Button btnAddSet;
        private Button btnDeleteSet;
        private Button btnDeleteRule;
        private Button btnAddRule;
        private ComboBox cmbErrorSet;
        private Label lblThen;
        private ComboBox cmbOutputSet;
        private ComboBox cmbDErrorSet;
        private Button lblSaveCurrentSet;
        private Button btnApply;
        private Label lblIf;
        private Label lblAnd;
        private Button btnGenerate5StandardSets;
        private Button btnGenerateRules;
        private DataGridView dgvRuleMatrix;
        private Label lblPreview;
        private Label lbldError;
        private Label lblErrorE;
        private Label lblErrorr1;
        private Label lblError;
        private Label label1lblErrorr3;
        private Label lblErrorr2;
    }
}