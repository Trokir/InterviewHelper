using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
using InterviewHelper.Forms;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

namespace InterviewHelper.FormServices
{
    public class QuestionFormFactory : IQuestionFormFactory
    {

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
