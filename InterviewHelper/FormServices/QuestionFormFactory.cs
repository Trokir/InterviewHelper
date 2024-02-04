using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
using InterviewHelper.Forms;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

namespace InterviewHelper.FormServices
{
    public class QuestionFormFactory : IQuestionFormFactory
    {
        public AddNewQuestionForm CreateNewQuestionForm(
            IEnumerable<Category> categories,
            IUnitOfWork unitOfWork,
            IMessageService messageService,
            IOpenAIQuestionService openAIQuestionService,
            IAudioRecordService audioRecordService,
            AppViewConfiguration config,
            TextEnvironment textEnvironment)
        {
            return new AddNewQuestionForm(categories, unitOfWork, messageService,
                openAIQuestionService, audioRecordService, config, textEnvironment);
        }

        public UpdateCurrentQuestionForm CreateUpdateQuestionForm(QuestionModel model, IUnitOfWork unitOfWork, IMessageService messageService)
        {
            return new UpdateCurrentQuestionForm(model, unitOfWork, messageService);
        }

        public DeleteQuestionForm DeleteQuestionForm(QuestionModel model, IUnitOfWork unitOfWork, IMessageService messageService)
        {
            return new DeleteQuestionForm(model, unitOfWork, messageService);

        }
    }
}
