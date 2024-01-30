namespace InterviewHelper.Forms
{
    partial class DeleteQuestionForm
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
            btnDelete = new Button();
            txtAnswer = new TextBox();
            txtQquestion = new TextBox();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.Location = new Point(73, 384);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(295, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Location = new Point(64, 111);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(663, 233);
            txtAnswer.TabIndex = 4;
            // 
            // txtQquestion
            // 
            txtQquestion.Location = new Point(73, 37);
            txtQquestion.Name = "txtQquestion";
            txtQquestion.Size = new Size(663, 27);
            txtQquestion.TabIndex = 3;
            // 
            // DeleteQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(txtAnswer);
            Controls.Add(txtQquestion);
            Name = "DeleteQuestionForm";
            Text = "DeleteQuestionForm";
            Load += DeleteQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private TextBox txtAnswer;
        private TextBox txtQquestion;
    }
}