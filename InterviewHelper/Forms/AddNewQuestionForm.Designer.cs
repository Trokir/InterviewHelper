namespace InterviewHelper.Forms
{
    partial class AddNewQuestionForm
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
            cmbCategory = new ComboBox();
            label3 = new Label();
            btnGpt = new Button();
            btnSave = new Button();
            txtComment = new TextBox();
            txtAnswer = new RichTextBox();
            btnRec = new Button();
            cmbLang = new ComboBox();
            btnSyRecord = new Button();
            groupBoxDevices = new GroupBox();
            groupBox1 = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pkbPic = new PictureBox();
            txtQuestion = new RichTextBox();
            groupBoxDevices.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pkbPic).BeginInit();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(15, 20);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(196, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 56);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Lang:";
            // 
            // btnGpt
            // 
            btnGpt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGpt.Location = new Point(112, 508);
            btnGpt.Margin = new Padding(3, 2, 3, 2);
            btnGpt.Name = "btnGpt";
            btnGpt.Size = new Size(130, 22);
            btnGpt.TabIndex = 7;
            btnGpt.Text = "Ask Chat GPT";
            btnGpt.UseVisualStyleBackColor = true;
            btnGpt.Click += btnGpt_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(1169, 511);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 22);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(30, 76);
            txtComment.Margin = new Padding(3, 2, 3, 2);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(181, 23);
            txtComment.TabIndex = 9;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAnswer.Location = new Point(91, 211);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(1173, 272);
            txtAnswer.TabIndex = 10;
            txtAnswer.Text = "";
            txtAnswer.TextChanged += txtAnswer_TextChanged;
            // 
            // btnRec
            // 
            btnRec.Location = new Point(162, 22);
            btnRec.Name = "btnRec";
            btnRec.Size = new Size(168, 50);
            btnRec.TabIndex = 11;
            btnRec.Text = "REC";
            btnRec.UseVisualStyleBackColor = true;
            btnRec.MouseDown += btnRec_MouseDown;
            btnRec.MouseUp += btnRec_MouseUp;
            // 
            // cmbLang
            // 
            cmbLang.FormattingEnabled = true;
            cmbLang.Items.AddRange(new object[] { "Angular", "C", "C#", "C++", "Go", "Java", "JavaScript", "Python", "React", "Swift", "TypeScript", "Visual Basic (VB.NET)" });
            cmbLang.Location = new Point(89, 48);
            cmbLang.Name = "cmbLang";
            cmbLang.Size = new Size(121, 23);
            cmbLang.TabIndex = 12;
            cmbLang.Text = "C#";
            // 
            // btnSyRecord
            // 
            btnSyRecord.Location = new Point(10, 22);
            btnSyRecord.Name = "btnSyRecord";
            btnSyRecord.Size = new Size(145, 50);
            btnSyRecord.TabIndex = 13;
            btnSyRecord.Text = "REC!";
            btnSyRecord.UseVisualStyleBackColor = true;
            btnSyRecord.MouseDown += btnSyRecord_MouseDown;
            btnSyRecord.MouseUp += btnSyRecord_MouseUp;
            // 
            // groupBoxDevices
            // 
            groupBoxDevices.Controls.Add(btnSyRecord);
            groupBoxDevices.Controls.Add(btnRec);
            groupBoxDevices.Location = new Point(32, 119);
            groupBoxDevices.Name = "groupBoxDevices";
            groupBoxDevices.Size = new Size(336, 86);
            groupBoxDevices.TabIndex = 14;
            groupBoxDevices.TabStop = false;
            groupBoxDevices.Text = "Audio";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbCategory);
            groupBox1.Controls.Add(cmbLang);
            groupBox1.Controls.Add(txtComment);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(142, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(226, 111);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "input";
            // 
            // pkbPic
            // 
            pkbPic.BackColor = SystemColors.MenuHighlight;
            pkbPic.Location = new Point(17, 23);
            pkbPic.Name = "pkbPic";
            pkbPic.Size = new Size(100, 88);
            pkbPic.SizeMode = PictureBoxSizeMode.Zoom;
            pkbPic.TabIndex = 16;
            pkbPic.TabStop = false;
            pkbPic.MouseEnter += pkbPic_MouseEnter;
            // 
            // txtQuestion
            // 
            txtQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtQuestion.Location = new Point(387, 17);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(877, 188);
            txtQuestion.TabIndex = 17;
            txtQuestion.Text = "";
            txtQuestion.KeyDown += txtQuestion_KeyDown;
            txtQuestion.KeyPress += txtQuestion_KeyPress;
            txtQuestion.MouseEnter += txtQuestion_MouseEnter;
            // 
            // AddNewQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1348, 542);
            Controls.Add(txtQuestion);
            Controls.Add(pkbPic);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxDevices);
            Controls.Add(txtAnswer);
            Controls.Add(btnSave);
            Controls.Add(btnGpt);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddNewQuestionForm";
            Text = "Add New Question";
            Load += AddNewQuestionForm_Load;
            groupBoxDevices.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pkbPic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCategory;
        private Label label3;
        private Button btnGpt;
        private Button btnSave;
        private TextBox txtComment;
        private RichTextBox txtAnswer;
        private Button btnRec;
        private ComboBox cmbLang;
        private Button btnSyRecord;
        private GroupBox groupBoxDevices;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pkbPic;
        private RichTextBox txtQuestion;
    }
}