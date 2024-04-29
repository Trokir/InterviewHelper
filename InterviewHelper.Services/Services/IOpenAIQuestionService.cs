using InterviewHelper.Core.Models;

namespace InterviewHelper.Services.Services
{
    public interface IOpenAIQuestionService
    {
        Task<string> GetGeneratedAnswerAsync(string question, string annotation, float temperature = 0.3F);
        Task<string> GetGeneratedAnswerAsync(string pattern, string annotation, string content, string skiils, float temperature = 0.3F);
        Task<string> DrawImageAsync(string message);
        Task<string> GetTextFromVoice(string path);
        IAsyncEnumerable<QuestionModel> GetPoolOfAnswersAsync(string[] strArr, string comment, string annotation, Category category);
        Task<HashSet<QuestionModel>> GetPoolOfAnswersAsync1(string[] strArr, string comment, string annotation, Category category);
        Task<string> GetTranslatedTest(string text, string sourceLang, string targetLang);
    }
}
