using HtmlAgilityPack;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        //private string ConvertPdfToHtml(string filePath)
        //{
            
        //        HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
        //        HtmlNode bodyNode = htmlDoc.CreateElement("body");
        //        htmlDoc.DocumentNode.AppendChild(bodyNode);

        //        foreach (var page in document.GetPages())
        //        {
        //            var words = page.GetWords();
        //            var words1 = page.GetMarkedContents();
        //            foreach (var word in words)
        //            {
        //                HtmlNode p = htmlDoc.CreateElement("p");
        //                p.InnerHtml = HtmlEntity.Entitize(word.Text);
        //                bodyNode.AppendChild(p);
        //            }
        //        }

        //        return htmlDoc.DocumentNode.OuterHtml;
            
        //}
        private void btnUpdateText_Click(object sender, EventArgs e)
        {
            var htmlText =rtbResume.Text;
            if(!string.IsNullOrEmpty(htmlText))
            {
                // Load the HTML string into the HtmlDocument
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlText);

                var section = doc.DocumentNode.SelectSingleNode("//section[@class='experience']");

                // If you need to get the inner content of the selected node
                if (section != null)
                {
                    string content = section.InnerHtml;
                    string promt = "";
                }
            }
        }
    }
}
