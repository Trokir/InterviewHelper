namespace InterviewHelper.Services.Services
{
    public interface IOpenAIQuestionService
    {
        Task<string> GetGeneratedAnswerAsync(string question, string annotation, float temperature = 0.3F);
        Task<string> DrawImageAsync(string message);
        Task<string> GetTextFromVoice(string path);
    }
}
