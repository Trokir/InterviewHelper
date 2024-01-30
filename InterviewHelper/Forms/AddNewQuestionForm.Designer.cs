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
            label1 = new Label();
            txtQuestion = new TextBox();
            label3 = new Label();
            btnGpt = new Button();
            btnSave = new Button();
            txtComment = new TextBox();
            txtAnswer = new RichTextBox();
            btnRec = new Button();
            cmbLang = new ComboBox();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(165, 10);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(196, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 16);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 2;
            label1.Text = "Existing Categories:";
            // 
            // txtQuestion
            // 
            txtQuestion.Font = new Font("Segoe UI", 12F);
            txtQuestion.Location = new Point(393, 23);
            txtQuestion.Margin = new Padding(3, 2, 3, 2);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.ScrollBars = ScrollBars.Both;
            txtQuestion.Size = new Size(871, 138);
            txtQuestion.TabIndex = 4;
            txtQuestion.KeyDown += txtQuestion_KeyDown;
            txtQuestion.KeyPress += txtQuestion_KeyPress;
            txtQuestion.MouseEnter += txtQuestion_MouseEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 64);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 6;
            label3.Text = "Answer:";
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
            txtComment.Location = new Point(180, 58);
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
            btnRec.Location = new Point(273, 99);
            btnRec.Name = "btnRec";
            btnRec.Size = new Size(75, 50);
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
            cmbLang.Location = new Point(39, 103);
            cmbLang.Name = "cmbLang";
            cmbLang.Size = new Size(121, 23);
            cmbLang.TabIndex = 12;
            cmbLang.Text = "C#";
            // 
            // AddNewQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1348, 542);
            Controls.Add(cmbLang);
            Controls.Add(btnRec);
            Controls.Add(txtAnswer);
            Controls.Add(txtComment);
            Controls.Add(btnSave);
            Controls.Add(btnGpt);
            Controls.Add(label3);
            Controls.Add(txtQuestion);
            Controls.Add(label1);
            Controls.Add(cmbCategory);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddNewQuestionForm";
            Text = "Add New Question";
            Load += AddNewQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private Label label1;
        private TextBox txtQuestion;
        private Label label3;
        private Button btnGpt;
        private Button btnSave;
        private TextBox txtComment;
        private RichTextBox txtAnswer;
        private Button btnRec;
        private ComboBox cmbLang;
    }
}