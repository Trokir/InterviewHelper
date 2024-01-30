namespace InterviewHelper.Forms
{
    partial class AddNewCategoryForm
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
            btnSave = new Button();
            txtCategory = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(97, 164);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(292, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCategory
            // 
            txtCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCategory.Location = new Point(72, 70);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(343, 27);
            txtCategory.TabIndex = 1;
            // 
            // AddNewCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 289);
            Controls.Add(txtCategory);
            Controls.Add(btnSave);
            Name = "AddNewCategoryForm";
            Text = "AddNewCategoryForm";
            Load += AddNewCategoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtCategory;
    }
}