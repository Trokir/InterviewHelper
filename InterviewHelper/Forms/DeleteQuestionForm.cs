using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;

namespace InterviewHelper.Forms
{
    public partial class DeleteQuestionForm : Form
    {
        private readonly QuestionModel _model;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageService _messageService;
        public DeleteQuestionForm(QuestionModel model,
            IUnitOfWork unitOfWork, IMessageService messageService)
        {
            _model = model;
            _unitOfWork = unitOfWork;
            _messageService = messageService;
            InitializeComponent();
        }

        private void DeleteQuestionForm_Load(object sender, EventArgs e)
        {
            txtAnswer.Text = _model.Answer;
            txtQquestion.Text = _model.Question;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAnswer.Text) && !string.IsNullOrWhiteSpace(txtQquestion.Text))
            {
                _model.Answer = txtAnswer.Text.Trim();
                _model.Question = txtQquestion.Text.Trim();
            }
            var dialog = _messageService.ShowCustomMessage("Delete this question?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                await _unitOfWork.QuestionRepository.DeleteAsync(_model);
                txtAnswer.Clear();
                txtQquestion.Clear();
                _messageService.ShowInfo("Current question has been deleted", "Info");
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
