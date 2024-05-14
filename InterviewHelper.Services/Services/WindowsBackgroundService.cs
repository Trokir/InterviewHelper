using InterviewHelper.Core.Config;
using InterviewHelper.Core.Pattern;
using InterviewHelper.Services.DTOs;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using Tesseract;

namespace InterviewHelper.Services.Services
{
    public class WindowsBackgroundService : BackgroundService
    {
        string annotation;
        string fileName;
        bool flag;
        string updatedText;
        private readonly ILogger<WindowsBackgroundService> _logger;
        private readonly AppViewConfiguration _config;
        private readonly IResumeService _resumeService;
        private ITelegramBotClient _bot { get; set; }

        public WindowsBackgroundService(ILogger<WindowsBackgroundService> logger,
            IOptions<AppViewConfiguration> options, IResumeService resumeService)
        {
            _logger = logger;
            _resumeService = resumeService;
            _config = options.Value;
            _bot = new TelegramBotClient(_config.BotApi);/*flud*/
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var receiverOptions = new ReceiverOptions
                    {
                        AllowedUpdates = Array.Empty<UpdateType>(),
                        ThrowPendingUpdates = true
                    };
                    var updateReceiver = new QueuedUpdateReceiver(_bot, receiverOptions);

                    try
                    {

                        await foreach (var update in updateReceiver.WithCancellation(stoppingToken))
                        {
                            if (update is Update message)
                            {

                                await HandleUpdateAsync(_bot, message, stoppingToken);
                            }

                        }

                    }
                    catch (ApiRequestException ex)
                    {
                        await HandleErrorAsync(ex, stoppingToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // When the stopping token is canceled, for example, a call made from services.msc,
                // we shouldn't exit with a non-zero exit code. In other words, this is expected...
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                Environment.Exit(1);
            }
        }
        public Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException)
            {
                _logger.LogError(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            }
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            var chat_message = new ChatMessage(update);
            var user = chat_message.GetCurrentUser();
            var message = chat_message.GetCurrentMessage();
            var userId = user.UserId;
            var text = chat_message.GetCurrentMessageText();
            if (userId == 5602891711)
            {
                if (message?.Type != null && message.Type == MessageType.Photo)
                {

                    var fileId = message.Photo.LastOrDefault()?.FileId;
                    if (!string.IsNullOrEmpty(fileId))
                    {
                        var fileInfo = await botClient.GetFileAsync(fileId);
                        var filePath = fileInfo.FilePath;

                        var savePath = Path.Combine(Path.GetTempPath(), fileInfo.FileUniqueId + ".jpg");

                        using (var saveImageStream = new FileStream(savePath, FileMode.Create))
                        {
                            await botClient.DownloadFileAsync(filePath, saveImageStream);
                        }
                        var tessPath = "E:\\Projects\\InterviewHelper\\InterviewHelper.Core\\tessdata\\";
                        using var engine = new TesseractEngine(tessPath, "eng", EngineMode.Default);
                        using var img = Pix.LoadFromFile(savePath);
                        using var page = engine.Process(img);
                        var content = page.GetText();
                        var result = await botClient.SendTextMessageAsync(message.Chat, content, cancellationToken: cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                        await Task.Delay(30000, cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: result.Chat, result.MessageId, cancellationToken);
                    }


                }

                if (message?.Type != null && message.Type == MessageType.Text)
                {


                    if (text.StartsWith("ann:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        int index = text.IndexOf(':');
                        if (index != -1)
                        {
                            annotation = (text.Substring(index + 1)).Trim();
                        }
                        var result = await botClient.SendTextMessageAsync(message.Chat, $"Annotation submitted", cancellationToken: cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                        await Task.Delay(3000, cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: result.Chat, result.MessageId, cancellationToken);
                        return;
                    }
                    if (text.StartsWith("file:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        int index = text.IndexOf(':');
                        if (index != -1)
                        {
                            fileName = (text.Substring(index + 1)).Trim();
                        }
                        var result = await botClient.SendTextMessageAsync(message.Chat, $"File name submitted", cancellationToken: cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                        await Task.Delay(3000, cancellationToken);
                        await botClient.DeleteMessageAsync(chatId: result.Chat, result.MessageId, cancellationToken);
                        return;
                    }
                    if (text.StartsWith("get", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string path = Path.Combine(@"C:\Users\troki\Desktop\Resumes", $"Kirill_Troshchevskii_{fileName}.pdf");
                        if (!string.IsNullOrEmpty(annotation) && !string.IsNullOrEmpty(fileName))
                        {
                            var responce = await _resumeService.UpdateHTMLContent(annotation, Resume.Pattern);
                            if (!string.IsNullOrEmpty(responce))
                            {
                                var result = await botClient.SendTextMessageAsync(message.Chat, $"Resume Updated", cancellationToken: cancellationToken);
                                updatedText = responce;
                                await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                                await Task.Delay(3000, cancellationToken);
                                await botClient.DeleteMessageAsync(chatId: result.Chat, result.MessageId, cancellationToken);
                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }
                                if (!string.IsNullOrEmpty(updatedText))
                                {
                                    _resumeService.SaveFileToLocalFolder(updatedText, path);
                                    var result1 = await botClient.SendTextMessageAsync(message.Chat, $"Resume Saved", cancellationToken: cancellationToken);
                                    // await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                                    await Task.Delay(3000, cancellationToken);
                                    await botClient.DeleteMessageAsync(chatId: result1.Chat, result1.MessageId, cancellationToken);
                                }
                            }

                            await using Stream stream = System.IO.File.OpenRead(path);
                            var fmessage = await botClient.SendDocumentAsync(
                                chatId: message.Chat,
                                document: InputFile.FromStream(stream: stream, fileName: $"Kirill_Troshchevskii_{fileName}.pdf"),
                                caption: $"here is your resume for {fileName}");
                            annotation = string.Empty;
                            fileName = string.Empty;
                        }
                        return;
                    }
                }
            }
            else
            {
                var result = await botClient.SendTextMessageAsync(message.Chat, $"Fuck off", cancellationToken: cancellationToken);
                await botClient.DeleteMessageAsync(chatId: message.Chat, message.MessageId, cancellationToken);
                await Task.Delay(3000, cancellationToken);
                await botClient.DeleteMessageAsync(chatId: result.Chat, result.MessageId, cancellationToken);
            }

        }






    }
}
