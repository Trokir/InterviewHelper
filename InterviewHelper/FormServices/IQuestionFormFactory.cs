using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
using InterviewHelper.Forms;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

namespace InterviewHelper.FormServices
{
    public interface IQuestionFormFactory
    {
        UpdateCurrentQuestionForm CreateUpdateQuestionForm
           (QuestionModel model, IUnitOfWork unitOfWork, IMessageService messageService);
        DeleteQuestionForm DeleteQuestionForm
          (QuestionModel model, IUnitOfWork unitOfWork, IMessageService messageService);
    }
}
