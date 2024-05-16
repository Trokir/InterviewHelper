using HtmlAgilityPack;

using InterviewHelper.Core.Pattern;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.tool.xml;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace InterviewHelper.Forms
{
    public partial class MainForm : Form
    {
        private async void btnParse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF Files|*.pdf|All Files|*.*";
            openFileDialog1.Title = "Select a PDF File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                rtbResume.Text = await _resumeService.ParsePdf(filePath);
                // Do something with the parsed text, like display it in a TextBox or a RichTextBox
            }
        }


        private async void btnUpdateText_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Updating experience";
            var updatedText = await _resumeService.UpdateHTMLContent(rtbPromt.Text, rtbResume.Text);
            toolStripStatusLabel1.Text = "Experience has been updated";
            rtbResume.Text = updatedText;
            string content = string.Empty;
        }

        private void btnSaveResume_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.Combine(@"C:\Users\troki\Desktop\Resumes", $"Kirill_Troshchevskii_{txtComp.Text}.pdf");
            var result = _resumeService.SaveFileToLocalFolder(rtbResume.Text, path, txtComp.Text);
            if (result)
            {
                MessageBox.Show("File has been successfully saved to the output folder", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefr_Click(object sender, EventArgs e)
        {
            rtbResume.Text = Resume.Pattern;
            rtbPromt.Text = string.Empty;
        }
    }
}
