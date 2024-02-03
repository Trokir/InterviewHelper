namespace InterviewHelper.Forms
{
    partial class CreateDiagramForm
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
            webViewDiagram = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            panelHidden = new Panel();
            ((System.ComponentModel.ISupportInitialize)webViewDiagram).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // webViewDiagram
            // 
            webViewDiagram.BackColor = SystemColors.Highlight;
            webViewDiagram.CreationProperties = null;
            webViewDiagram.DefaultBackgroundColor = Color.White;
            webViewDiagram.Dock = DockStyle.Fill;
            webViewDiagram.Location = new Point(0, 0);
            webViewDiagram.Name = "webViewDiagram";
            webViewDiagram.Size = new Size(1016, 612);
            webViewDiagram.TabIndex = 0;
            webViewDiagram.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(webViewDiagram);
            panel1.Location = new Point(29, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1016, 612);
            panel1.TabIndex = 1;
            // 
            // panelHidden
            // 
            panelHidden.Location = new Point(12, 3);
            panelHidden.Name = "panelHidden";
            panelHidden.Size = new Size(175, 64);
            panelHidden.TabIndex = 2;
            panelHidden.MouseMove += panelHidden_MouseMove;
            // 
            // CreateDiagramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 660);
            Controls.Add(panel1);
            Controls.Add(panelHidden);
            Name = "CreateDiagramForm";
            Text = "CreateDiagramForm";
            ((System.ComponentModel.ISupportInitialize)webViewDiagram).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewDiagram;
        private Panel panel1;
        private Panel panelHidden;
    }
}