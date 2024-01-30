namespace InterviewHelper.Forms
{
    partial class TeztFromPictuireForm
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
            pcbImage = new PictureBox();
            txtText = new TextBox();
            btnAsk = new Button();
            txtAnswer = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pcbImage).BeginInit();
            SuspendLayout();
            // 
            // pcbImage
            // 
            pcbImage.BorderStyle = BorderStyle.Fixed3D;
            pcbImage.Location = new Point(36, 25);
            pcbImage.Name = "pcbImage";
            pcbImage.Size = new Size(376, 402);
            pcbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbImage.TabIndex = 0;
            pcbImage.TabStop = false;
            // 
            // txtText
            // 
            txtText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtText.Font = new Font("Segoe UI", 12F);
            txtText.Location = new Point(454, 30);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.ScrollBars = ScrollBars.Both;
            txtText.Size = new Size(420, 397);
            txtText.TabIndex = 1;
            // 
            // btnAsk
            // 
            btnAsk.Location = new Point(36, 770);
            btnAsk.Name = "btnAsk";
            btnAsk.Size = new Size(201, 29);
            btnAsk.TabIndex = 2;
            btnAsk.Text = "Ask GPT";
            btnAsk.UseVisualStyleBackColor = true;
            btnAsk.Click += btnAsk_Click;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Font = new Font("Segoe UI", 12F);
            txtAnswer.Location = new Point(36, 446);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Both;
            txtAnswer.Size = new Size(838, 318);
            txtAnswer.TabIndex = 3;
            // 
            // TeztFromPictuireForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(908, 842);
            Controls.Add(txtAnswer);
            Controls.Add(btnAsk);
            Controls.Add(txtText);
            Controls.Add(pcbImage);
            Name = "TeztFromPictuireForm";
            Text = "Text From Pictuire Form";
            Load += TeztFromPictuireForm_Load;
            ((System.ComponentModel.ISupportInitialize)pcbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pcbImage;
        private TextBox txtText;
        private Button btnAsk;
        private TextBox txtAnswer;
    }
}