

using Google.Cloud.Speech.V1;

using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
using InterviewHelper.Core.Models.DTOs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InterviewHelper.Services.Services
{
    public class OpenAIQuestionService : IOpenAIQuestionService
    {
        private readonly AppViewConfiguration _config;
        private readonly IServiceProvider _factory;
        public OpenAIQuestionService(IOptions<AppViewConfiguration> options,
            IServiceProvider factory)
        {
            _config = options.Value;
            _factory = factory;
        }
        public async Task<string> GetGeneratedAnswerAsync(string question, string annotation, float temperature = 0.3F)
        {
            var fullQuestion = $"{question} {annotation}";
            //  var fullQuestion = question;
            var modelJson = new
            {
                model = "gpt-4-0125-preview",
                messages = new[] {
                new {
                    role = "system",
                    content = fullQuestion
                }
            },
                temperature = temperature,
                max_tokens = 2000,
                top_p = 1.0,
                frequency_penalty = 0.0,
                presence_penalty = 0.0,
                stop = new[] { "🍍" }
            };
            var json = JsonSerializer.Serialize(modelJson);
            using var scope = _factory.CreateScope();
            var httpClient = scope.ServiceProvider
                                    .GetRequiredService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _config.ChatGptPath);

            request.Headers.Add("Authorization", "Bearer " + _config.ApiKey);

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var answerModel = JsonSerializer.Deserialize<CodeGenResponceModel>(responseBody);
            var result = answerModel?.choices?.FirstOrDefault()?.message.content ?? string.Empty;
            return result;
        }



        public async Task<string> DrawImageAsync(string message)
        {

            var modelJson = new OpenAiDrawModel
            {
                model = "dall-e-3",
                prompt = message,
                n = 1,
                size = "1024x1024"
            };
            var json = JsonSerializer.Serialize(modelJson);
            using var scope = _factory.CreateScope();
            var httpClient = scope.ServiceProvider
                                    .GetRequiredService<IHttpClientFactory>();
            var client = httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _config.ChatGptPath);

            request.Headers.Add("Authorization", "Bearer " + _config.ApiKey);

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<string> GetTextFromVoice(string audioFilePath)
        {
            await Task.Delay(10);
            try
            {
                // Replace "path/to/your/credentials.json" with the path to your JSON key file.
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", _config.GoogleText);
                var sb = new StringBuilder();
                var speechClient = SpeechClient.Create();
                var response = Recognize(audioFilePath, speechClient);

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        sb.Append(alternative.Transcript);
                    }
                }
                return sb.ToString();
            }
            catch
            {

                return "";
            }

        }
        RecognizeResponse Recognize(string filePath, SpeechClient speechClient)
        {
            var audio = RecognitionAudio.FromFile(filePath);
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Mp3,
                SampleRateHertz = 16000, // Adjust based on your audio file
                LanguageCode = "en-US", // Adjust based on your language
                MaxAlternatives = 1,
                EnableSpokenPunctuation = true
            };

            var request = new RecognizeRequest
            {
                Audio = audio,
                Config = config,
            };

            return speechClient.Recognize(request);
        }

        public async Task<HashSet<QuestionModel>> GetPoolOfAnswersAsync1(string[] strArr,string comment, string annotation,Category category)
        {
            var poolList = new HashSet<QuestionModel>();
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 3
            };

            await Parallel.ForEachAsync(strArr, options, async (item, ct) => {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    var answer = await GetGeneratedAnswerAsync(item + " " + comment, annotation, 0.7F);
                    if (category is not null &&
                        !string.IsNullOrWhiteSpace(answer))
                    {
                        //txtAnswer.Clear();
                        //txtAnswer.Text = answer;
                        var newQuestion = new QuestionModel
                        {
                            Category = category,
                            Question = item,
                            Answer = answer
                        };
                        poolList.Add(newQuestion);
                        Debug.WriteLine(newQuestion);
                    }
                }
            });
            return poolList;
        }

        public async IAsyncEnumerable<QuestionModel> GetPoolOfAnswersAsync(string[] strArr, string comment, string annotation, Category category)
        {
            foreach (var item in strArr)
            {
                var answer = await GetGeneratedAnswerAsync($"{item} {comment}", annotation, 0.7F);
                if (category is not null &&
                    !string.IsNullOrWhiteSpace(answer))
                {
                   
                    var newQuestion = new QuestionModel
                    {
                        Category = category,
                        Question = item,
                        Answer = answer
                    };
                    Debug.WriteLine(newQuestion);
                    yield return newQuestion;
                }
                
            }
        }
    }
}
