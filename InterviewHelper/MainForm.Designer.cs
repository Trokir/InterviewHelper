namespace InterviewHelper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cmbCategory = new ComboBox();
            btnRefresh = new Button();
            btnAddNew = new Button();
            btnAddCategory = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnShowPic = new Button();
            txtSearch = new TextBox();
            dgvQuestions = new DataGridView();
            groupBox1 = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtAnswer = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(14, 45);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(225, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(5, 61);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 22);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddNew.Location = new Point(5, 38);
            btnAddNew.Margin = new Padding(3, 2, 3, 2);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(142, 22);
            btnAddNew.TabIndex = 4;
            btnAddNew.Text = "Add new Question";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddCategory.Location = new Point(5, 11);
            btnAddCategory.Margin = new Padding(3, 2, 3, 2);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(142, 22);
            btnAddCategory.TabIndex = 5;
            btnAddCategory.Text = "Add new Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdate.Location = new Point(172, 11);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 22);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update this";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.Location = new Point(172, 38);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 22);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete this";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShowPic
            // 
            btnShowPic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnShowPic.Location = new Point(172, 61);
            btnShowPic.Margin = new Padding(3, 2, 3, 2);
            btnShowPic.Name = "btnShowPic";
            btnShowPic.Size = new Size(145, 22);
            btnShowPic.TabIndex = 8;
            btnShowPic.Text = "Picture text";
            btnShowPic.UseVisualStyleBackColor = true;
            btnShowPic.Click += btnShowPic_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.InactiveCaption;
            txtSearch.Location = new Point(14, 9);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(225, 23);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.MouseEnter += txtSearch_MouseEnter;
            // 
            // dgvQuestions
            // 
            dgvQuestions.AllowUserToOrderColumns = true;
            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestions.BorderStyle = BorderStyle.Fixed3D;
            dgvQuestions.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuestions.Location = new Point(10, 77);
            dgvQuestions.Margin = new Padding(3, 2, 3, 2);
            dgvQuestions.Name = "dgvQuestions";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvQuestions.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvQuestions.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dgvQuestions.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestions.Size = new Size(541, 282);
            dgvQuestions.TabIndex = 10;
            dgvQuestions.SelectionChanged += dgvQuestions_SelectionChanged;
            dgvQuestions.KeyDown += dgvQuestions_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlDark;
            groupBox1.Controls.Add(btnAddCategory);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnShowPic);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Location = new Point(14, 368);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(345, 87);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAnswer.Location = new Point(576, 42);
            txtAnswer.Margin = new Padding(10);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ShowSelectionMargin = true;
            txtAnswer.Size = new Size(734, 397);
            txtAnswer.TabIndex = 12;
            txtAnswer.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 464);
            Controls.Add(txtAnswer);
            Controls.Add(groupBox1);
            Controls.Add(dgvQuestions);
            Controls.Add(txtSearch);
            Controls.Add(cmbCategory);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "Interview helper";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private Button btnRefresh;
        private Button btnAddNew;
        private Button btnAddCategory;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnShowPic;
        private TextBox txtSearch;
        private DataGridView dgvQuestions;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RichTextBox txtAnswer;
    }
}
