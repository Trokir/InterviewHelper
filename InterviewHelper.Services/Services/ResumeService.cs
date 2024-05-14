using NAudio.Wave;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterviewHelper.Core.Pattern;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.tool.xml;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewHelper.Services.Services
{
    public class ResumeService : IResumeService
    {
        private readonly OpenAIQuestionService _openAIQuestionService;
        public IServiceProvider _services { get; }
        public ResumeService(IServiceProvider services)
        {
            _services = services;

        }

        public bool SaveFileToLocalFolder(string inputText, string filePath, string flieExt = "")
        {
            try
            {
                using Document document = new Document();
                string outputPath = System.IO.Path.Combine(filePath);

                using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();
                    using (TextReader reader = new StringReader(inputText))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, reader);
                    }
                    document.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> UpdateHTMLContent(string promt, string resumeText)
        {
            using (var scope = _services.CreateScope())
            {
                var _openAIQuestionService = scope.ServiceProvider.GetRequiredService<IOpenAIQuestionService>();


                string input = string.Empty;
                if (!string.IsNullOrEmpty(resumeText))
                {
                    // Load the HTML string into the HtmlDocument
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(resumeText);

                    var section = doc.DocumentNode.SelectSingleNode("//section[@class='experience']");

                    if (section != null)
                    {
                        // Replace the inner text or inner HTML of the section
                        var resp = await _openAIQuestionService
                            .GetGeneratedAnswerAsync($"Goal: to update the content in html text so that" +
                            $" the recruiters'" +
                            $" ATS finds a 100% match in terms of the annotation below." +
                            $"  Result: Bring back the updated html" +
                            $" text with the content of the resume for the American market," +
                            $" competently designed. Your answer: HTML text with resume" +
                            $" for Senior Full Stack Dotnet developer (not team lead, " +
                            $"remove all mentionig about leading, in the skiis section set " +
                            $"just list of skills without any additional details" +
                            $"\n here is HTML page :\n {Resume.Pattern} \n",
                            $"and here is an annotation:{promt}", 0.8f);
                        input = resp.Substring(0, resp.LastIndexOf(">") + 1);
                        int index = input.IndexOf('<') - 1;
                        if (index != -1)
                        {
                            input = input.Substring(index + 1);
                        }

                    }
                }

                return input;
            }
        }

        public async Task<string> ParsePdf(string filePath)
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
    }
}
