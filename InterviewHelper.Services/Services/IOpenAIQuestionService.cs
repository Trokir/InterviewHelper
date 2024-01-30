namespace InterviewHelper.Services.Services
{
    public interface IOpenAIQuestionService
    {
        Task<string> GetAnswerAsync(string question,string annotation);
        Task<string> DrawImageAsync(string message);
        Task<string> GetTextFromVoice(string path);
        Task<string> GetGeneratedCodeAsync(string question, string annotation);
    }
}
