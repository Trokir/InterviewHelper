namespace InterviewHelper.Services.Services
{
    public interface IOpenAIQuestionService
    {
        Task<string> GetAnswerAsync(string question);
        Task<string> DrawImageAsync(string message);
        Task<string> GetTextFromVoice(string path);
    }
}
