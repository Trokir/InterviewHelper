namespace InterviewHelper.Services.Services
{
    public interface IResumeService
    {
        bool SaveFileToLocalFolder(string inputText, string filePath, string flieExt = "");
        Task<string> ParsePdf(string filePath);
        Task<string> UpdateHTMLContent(string promt, string resumeText);
    }
}
