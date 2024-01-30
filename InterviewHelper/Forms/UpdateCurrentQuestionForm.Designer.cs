namespace InterviewHelper.Forms
{
    partial class UpdateCurrentQuestionForm
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
            txtQquestion = new TextBox();
            txtAnswer = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtQquestion
            // 
            txtQquestion.Location = new Point(84, 26);
            txtQquestion.Name = "txtQquestion";
            txtQquestion.Size = new Size(663, 27);
            txtQquestion.TabIndex = 0;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Location = new Point(75, 100);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Both;
            txtAnswer.Size = new Size(663, 233);
            txtAnswer.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdate.Location = new Point(84, 373);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(295, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // UpdateCurrentQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(txtAnswer);
            Controls.Add(txtQquestion);
            Name = "UpdateCurrentQuestionForm";
            Text = "Update Info";
            Load += UpdateCurrentQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQquestion;
        private TextBox txtAnswer;
        private Button btnUpdate;
    }
}