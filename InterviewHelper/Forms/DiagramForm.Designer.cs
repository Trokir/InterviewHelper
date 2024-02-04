namespace InterviewHelper.Forms
{
    partial class DiagramForm
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
            panel1 = new Panel();
            pcbImage = new PictureBox();
            txtInfo = new TextBox();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            cmbFiles = new ComboBox();
            btnSave = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbImage).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pcbImage);
            panel1.Location = new Point(43, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(979, 331);
            panel1.TabIndex = 0;
            // 
            // pcbImage
            // 
            pcbImage.BackColor = SystemColors.InactiveCaption;
            pcbImage.Dock = DockStyle.Fill;
            pcbImage.Location = new Point(0, 0);
            pcbImage.Name = "pcbImage";
            pcbImage.Size = new Size(979, 331);
            pcbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pcbImage.TabIndex = 0;
            pcbImage.TabStop = false;
            // 
            // txtInfo
            // 
            txtInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInfo.Location = new Point(43, 25);
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(979, 23);
            txtInfo.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = SystemColors.AppWorkspace;
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(cmbFiles);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(43, 435);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(979, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(17, 57);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(198, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete file";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cmbFiles
            // 
            cmbFiles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbFiles.FormattingEnabled = true;
            cmbFiles.Location = new Point(384, 27);
            cmbFiles.Name = "cmbFiles";
            cmbFiles.Size = new Size(498, 29);
            cmbFiles.TabIndex = 1;
            cmbFiles.SelectedIndexChanged += cmbFiles_SelectedIndexChanged;
            cmbFiles.TextUpdate += cmbFiles_TextUpdate;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(17, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(198, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save file";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // DiagramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 547);
            Controls.Add(groupBox1);
            Controls.Add(txtInfo);
            Controls.Add(panel1);
            Name = "DiagramForm";
            Text = "DiagramForm";
            Load += DiagramForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcbImage).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pcbImage;
        private TextBox txtInfo;
        private GroupBox groupBox1;
        private Button btnSave;
        private ComboBox cmbFiles;
        private Button btnDelete;
    }
}