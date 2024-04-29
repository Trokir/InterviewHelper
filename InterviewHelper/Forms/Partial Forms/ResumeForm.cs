﻿using HtmlAgilityPack;

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
                rtbResume.Text = await ParsePdf(filePath);
                // Do something with the parsed text, like display it in a TextBox or a RichTextBox
            }
        }
        private async Task<string> ParsePdf(string filePath)
        {
            var text = new StringBuilder();

            using (PdfReader reader = new PdfReader(filePath))
            {
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                HtmlNode bodyNode = htmlDoc.CreateElement("body");
                htmlDoc.DocumentNode.AppendChild(bodyNode);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    var textP = PdfTextExtractor.GetTextFromPage(reader, page);
                    text.AppendLine(textP);
                }
            }
            var convertedText = await _openAIQuestionService.GetGeneratedAnswerAsync($"Make this text formatted and styled to html for resume \n", text.ToString());

            return convertedText;
        }
       
        private async void btnUpdateText_Click(object sender, EventArgs e)
        {
            string content = string.Empty;
            var htmlText =rtbResume.Text;
            if(!string.IsNullOrEmpty(htmlText))
            {
                // Load the HTML string into the HtmlDocument
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlText);

                var section = doc.DocumentNode.SelectSingleNode("//section[@class='experience']");



                if (section != null)
                {
                    toolStripStatusLabel3.Text = "Updating experience";
                    // Replace the inner text or inner HTML of the section
                    var resp = await _openAIQuestionService
                        .GetGeneratedAnswerAsync($"Change the content on the HTML page using this information." +
                        $" All skills and abilities should be added to the" +
                        $" context in the experience and skills section. all skills from informaton must be included and modified for resume text" +
                        $" Return the updated HTML as a response. here is html : {Resume.Pattern} \n",
                        $"here is info:{rtbPromt.Text}");
                    toolStripStatusLabel3.Text = "Experience has been updated";
                   var input = resp.Substring(0, resp.LastIndexOf(">") + 1);
                    int index = input.IndexOf('<')-1;
                    if (index != -1)
                    {
                        input = input.Substring(index + 1);
                    }
                    rtbResume.Text = input;
                }
            }
        }
        private void btnSaveResume_Click(object sender, EventArgs e)
        {
            // Создание документа PDF
            Document document = new Document();
            string outputPath = System.IO.Path.Combine(@"C:\Users\troki\Desktop\Resumes", $"Kirill_Troshchevskii_{txtComp.Text}.pdf");

            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                using (TextReader reader = new StringReader(rtbResume.Text))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, reader);
                }
                document.Close();
            }
        }
    }
}
