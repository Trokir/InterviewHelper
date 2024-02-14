namespace InterviewHelper.Forms
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
            btnAddCategory = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            dgvQuestions = new DataGridView();
            groupBox1 = new GroupBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            txtAnswer = new RichTextBox();
            mainMenutabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            txtQuestion = new RichTextBox();
            pkbPic = new PictureBox();
            groupBox2 = new GroupBox();
            cmbxCategory = new ComboBox();
            cmbLang = new ComboBox();
            txtComment = new TextBox();
            label3 = new Label();
            groupBoxDevices = new GroupBox();
            btnSyRecord = new Button();
            btnRec = new Button();
            txtxAnswer = new RichTextBox();
            btnSave = new Button();
            btnxGpt = new Button();
            tabPage3 = new TabPage();
            panel1 = new Panel();
            pcbImage = new PictureBox();
            groupBox3 = new GroupBox();
            btndDelete = new Button();
            cmbFiles = new ComboBox();
            btndSave = new Button();
            txtInfo = new TextBox();
            tabPage4 = new TabPage();
            panel2 = new Panel();
            webViewDiagram = new Microsoft.Web.WebView2.WinForms.WebView2();
            panelHidden = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            groupBox1.SuspendLayout();
            mainMenutabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pkbPic).BeginInit();
            groupBox2.SuspendLayout();
            groupBoxDevices.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbImage).BeginInit();
            groupBox3.SuspendLayout();
            tabPage4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewDiagram).BeginInit();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(15, 54);
            cmbCategory.Margin = new Padding(3, 2, 3, 2);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(225, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(5, 38);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 22);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
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
            btnUpdate.Location = new Point(345, 12);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(167, 22);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update this";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.Location = new Point(345, 38);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(167, 22);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete this";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.InactiveCaption;
            txtSearch.Location = new Point(15, 18);
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
            dgvQuestions.Location = new Point(11, 86);
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
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Location = new Point(15, 377);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(537, 87);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // txtAnswer
            // 
            txtAnswer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnswer.BackColor = SystemColors.Menu;
            txtAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAnswer.Location = new Point(565, 18);
            txtAnswer.Margin = new Padding(10);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ShowSelectionMargin = true;
            txtAnswer.Size = new Size(724, 766);
            txtAnswer.TabIndex = 12;
            txtAnswer.Text = "";
            // 
            // tabControl1
            // 
            mainMenutabControl.Controls.Add(tabPage1);
            mainMenutabControl.Controls.Add(tabPage2);
            mainMenutabControl.Controls.Add(tabPage3);
            mainMenutabControl.Controls.Add(tabPage4);
            mainMenutabControl.Dock = DockStyle.Fill;
            mainMenutabControl.Location = new Point(0, 0);
            mainMenutabControl.Name = "tabControl1";
            mainMenutabControl.SelectedIndex = 0;
            mainMenutabControl.Size = new Size(1431, 845);
            mainMenutabControl.TabIndex = 13;
            mainMenutabControl.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtSearch);
            tabPage1.Controls.Add(txtAnswer);
            tabPage1.Controls.Add(cmbCategory);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(dgvQuestions);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1423, 817);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtQuestion);
            tabPage2.Controls.Add(pkbPic);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBoxDevices);
            tabPage2.Controls.Add(txtxAnswer);
            tabPage2.Controls.Add(btnSave);
            tabPage2.Controls.Add(btnxGpt);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1423, 817);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clever";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtQuestion
            // 
            txtQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtQuestion.BackColor = SystemColors.MenuBar;
            txtQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtQuestion.Location = new Point(431, 37);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(946, 304);
            txtQuestion.TabIndex = 24;
            txtQuestion.Text = "";
            txtQuestion.KeyDown += txtQuestion_KeyDown;
            txtQuestion.KeyPress += txtQuestion_KeyPress;
            txtQuestion.MouseEnter += txtQuestion_MouseEnter;
            // 
            // pkbPic
            // 
            pkbPic.BackColor = SystemColors.MenuHighlight;
            pkbPic.Location = new Point(8, 16);
            pkbPic.Name = "pkbPic";
            pkbPic.Size = new Size(179, 142);
            pkbPic.SizeMode = PictureBoxSizeMode.Zoom;
            pkbPic.TabIndex = 23;
            pkbPic.TabStop = false;
            pkbPic.MouseEnter += pkbPic_MouseEnter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Gainsboro;
            groupBox2.Controls.Add(cmbxCategory);
            groupBox2.Controls.Add(cmbLang);
            groupBox2.Controls.Add(txtComment);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(193, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(232, 111);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "input";
            // 
            // cmbxCategory
            // 
            cmbxCategory.FormattingEnabled = true;
            cmbxCategory.Location = new Point(24, 20);
            cmbxCategory.Margin = new Padding(3, 2, 3, 2);
            cmbxCategory.Name = "cmbxCategory";
            cmbxCategory.Size = new Size(186, 23);
            cmbxCategory.TabIndex = 0;
            cmbxCategory.SelectedIndexChanged += cmbxCategory_SelectedIndexChanged;
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
            // txtComment
            // 
            txtComment.Location = new Point(30, 76);
            txtComment.Margin = new Padding(3, 2, 3, 2);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(181, 23);
            txtComment.TabIndex = 9;
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
            // groupBoxDevices
            // 
            groupBoxDevices.BackColor = Color.Gainsboro;
            groupBoxDevices.Controls.Add(btnSyRecord);
            groupBoxDevices.Controls.Add(btnRec);
            groupBoxDevices.Location = new Point(8, 179);
            groupBoxDevices.Name = "groupBoxDevices";
            groupBoxDevices.Size = new Size(417, 86);
            groupBoxDevices.TabIndex = 21;
            groupBoxDevices.TabStop = false;
            groupBoxDevices.Text = "Audio";
            // 
            // btnSyRecord
            // 
            btnSyRecord.Location = new Point(10, 22);
            btnSyRecord.Name = "btnSyRecord";
            btnSyRecord.Size = new Size(158, 50);
            btnSyRecord.TabIndex = 13;
            btnSyRecord.Text = "REC!";
            btnSyRecord.UseVisualStyleBackColor = true;
            btnSyRecord.MouseDown += btnSyRecord_MouseDown;
            btnSyRecord.MouseUp += btnSyRecord_MouseUp;
            // 
            // btnRec
            // 
            btnRec.Location = new Point(228, 22);
            btnRec.Name = "btnRec";
            btnRec.Size = new Size(168, 50);
            btnRec.TabIndex = 11;
            btnRec.Text = "REC";
            btnRec.UseVisualStyleBackColor = true;
            btnRec.MouseDown += btnRec_MouseDown;
            btnRec.MouseUp += btnRec_MouseUp;
            // 
            // txtxAnswer
            // 
            txtxAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtxAnswer.BackColor = SystemColors.InactiveCaption;
            txtxAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtxAnswer.Location = new Point(18, 418);
            txtxAnswer.Name = "txtxAnswer";
            txtxAnswer.Size = new Size(1359, 319);
            txtxAnswer.TabIndex = 20;
            txtxAnswer.Text = "";
            txtxAnswer.TextChanged += txtxAnswer_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.Gainsboro;
            btnSave.Location = new Point(1197, 763);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 34);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnxGpt
            // 
            btnxGpt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnxGpt.BackColor = Color.Silver;
            btnxGpt.Location = new Point(142, 762);
            btnxGpt.Margin = new Padding(3, 2, 3, 2);
            btnxGpt.Name = "btnxGpt";
            btnxGpt.Size = new Size(144, 35);
            btnxGpt.TabIndex = 18;
            btnxGpt.Text = "Ask Chat GPT";
            btnxGpt.UseVisualStyleBackColor = false;
            btnxGpt.Click += btnxGpt_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel1);
            tabPage3.Controls.Add(groupBox3);
            tabPage3.Controls.Add(txtInfo);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1423, 817);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Diagram";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pcbImage);
            panel1.Location = new Point(21, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(1367, 592);
            panel1.TabIndex = 3;
            // 
            // pcbImage
            // 
            pcbImage.BackColor = SystemColors.InactiveCaption;
            pcbImage.Dock = DockStyle.Fill;
            pcbImage.Location = new Point(0, 0);
            pcbImage.Name = "pcbImage";
            pcbImage.Size = new Size(1367, 592);
            pcbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pcbImage.TabIndex = 0;
            pcbImage.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = SystemColors.AppWorkspace;
            groupBox3.Controls.Add(btndDelete);
            groupBox3.Controls.Add(cmbFiles);
            groupBox3.Controls.Add(btndSave);
            groupBox3.Font = new Font("Segoe UI", 12F);
            groupBox3.Location = new Point(21, 688);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1367, 110);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Menu";
            // 
            // btndDelete
            // 
            btndDelete.Font = new Font("Segoe UI", 12F);
            btndDelete.Location = new Point(17, 57);
            btndDelete.Name = "btndDelete";
            btndDelete.Size = new Size(198, 29);
            btndDelete.TabIndex = 2;
            btndDelete.Text = "Delete file";
            btndDelete.UseVisualStyleBackColor = true;
            btndDelete.Click += btndDelete_Click;
            // 
            // cmbFiles
            // 
            cmbFiles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbFiles.FormattingEnabled = true;
            cmbFiles.Location = new Point(384, 27);
            cmbFiles.Name = "cmbFiles";
            cmbFiles.Size = new Size(921, 29);
            cmbFiles.TabIndex = 1;
            cmbFiles.SelectedIndexChanged += cmbFiles_SelectedIndexChanged;
            cmbFiles.TextUpdate += cmbFiles_TextUpdate;
            // 
            // btndSave
            // 
            btndSave.Font = new Font("Segoe UI", 12F);
            btndSave.Location = new Point(17, 22);
            btndSave.Name = "btndSave";
            btndSave.Size = new Size(198, 29);
            btndSave.TabIndex = 0;
            btndSave.Text = "Save file";
            btndSave.UseVisualStyleBackColor = true;
            btndSave.Click += btndSave_Click;
            // 
            // txtInfo
            // 
            txtInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInfo.Location = new Point(21, 16);
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(1367, 23);
            txtInfo.TabIndex = 2;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(panel2);
            tabPage4.Controls.Add(panelHidden);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1423, 817);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Show Diagram";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(webViewDiagram);
            panel2.Location = new Point(26, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(1372, 749);
            panel2.TabIndex = 4;
            // 
            // webViewDiagram
            // 
            webViewDiagram.BackColor = SystemColors.Highlight;
            webViewDiagram.CreationProperties = null;
            webViewDiagram.DefaultBackgroundColor = Color.White;
            webViewDiagram.Dock = DockStyle.Fill;
            webViewDiagram.Location = new Point(0, 0);
            webViewDiagram.Name = "webViewDiagram";
            webViewDiagram.Size = new Size(1372, 749);
            webViewDiagram.TabIndex = 0;
            webViewDiagram.ZoomFactor = 1D;
            // 
            // panelHidden
            // 
            panelHidden.Location = new Point(8, 3);
            panelHidden.Name = "panelHidden";
            panelHidden.Size = new Size(175, 64);
            panelHidden.TabIndex = 3;
            panelHidden.MouseMove += panelHidden_MouseMove;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 845);
            Controls.Add(mainMenutabControl);
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Interview helper";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            groupBox1.ResumeLayout(false);
            mainMenutabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pkbPic).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBoxDevices.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcbImage).EndInit();
            groupBox3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewDiagram).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCategory;
        private Button btnRefresh;
        private Button btnAddCategory;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearch;
        private DataGridView dgvQuestions;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RichTextBox txtAnswer;
        private TabControl mainMenutabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private RichTextBox txtQuestion;
        private PictureBox pkbPic;
        private GroupBox groupBox2;
        private ComboBox cmbxCategory;
        private ComboBox cmbLang;
        private TextBox txtComment;
        private Label label3;
        private GroupBox groupBoxDevices;
        private Button btnSyRecord;
        private Button btnRec;
        private RichTextBox txtxAnswer;
        private Button btnSave;
        private Button btnxGpt;
        private TextBox txtInfo;
        private Panel panel1;
        private PictureBox pcbImage;
        private GroupBox groupBox3;
        private Button btndDelete;
        private ComboBox cmbFiles;
        private Button btndSave;
        private Panel panelHidden;
        private Panel panel2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewDiagram;
    }
}
