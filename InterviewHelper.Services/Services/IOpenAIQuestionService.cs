using InterviewHelper.Core.Models;

namespace InterviewHelper.Services.Services
{
    public interface IOpenAIQuestionService
    {
        Task<string> GetGeneratedAnswerAsync(string question, string annotation, float temperature = 0.3F);
        Task<string> DrawImageAsync(string message);
        Task<string> GetTextFromVoice(string path);
        Task<HashSet<QuestionModel>> GetPoolOfAnswersAsync(string[] strArr, string comment, string annotation, Category category);
    }
}
