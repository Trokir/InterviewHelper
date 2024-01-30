

using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;

namespace InterviewHelper.Forms
{
    public partial class UpdateCurrentQuestionForm : Form
    {

        private readonly QuestionModel _model;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageService _messageService;
        public UpdateCurrentQuestionForm(QuestionModel model,
            IUnitOfWork unitOfWork, IMessageService messageService)
        {
            _model = model;
            _unitOfWork = unitOfWork;
            _messageService = messageService;
            InitializeComponent();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAnswer.Text) && !string.IsNullOrWhiteSpace(txtQquestion.Text))
            {
                _model.Answer = txtAnswer.Text.Trim();
                _model.Question = txtQquestion.Text.Trim();
            }
            var dialog = _messageService.ShowCustomMessage("Update this question?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                await _unitOfWork.QuestionRepository.UpdateAsync(_model);
                _messageService.ShowInfo("Current question has been updated", "Info");
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
                this.Close();
            }
        }

        private void UpdateCurrentQuestionForm_Load(object sender, EventArgs e)
        {
            txtAnswer.Text = _model.Answer;
            txtQquestion.Text = _model.Question;
        }
    }
}
