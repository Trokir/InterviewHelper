using InterviewHelper.Core.Helper;
using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InterviewHelper.Forms
{
    public partial class AddNewQuestionForm : Form
    {
        private readonly IUnitOfWork _commandService;
        private readonly IEnumerable<Category> _categories;
        private readonly IMessageService _messageService;
        private readonly IOpenAIQuestionService _openAIQuestionService;
        private readonly IAudioRecordService _audioRecordService;
        private Category _category;

        public AddNewQuestionForm(
            IEnumerable<Category> categories,
            IUnitOfWork commandService,
          IMessageService messageService,
          IOpenAIQuestionService openAIQuestionService,
          IAudioRecordService audioRecordService)
        {
            InitializeComponent();
            _categories = categories;
            _commandService = commandService;
            _messageService = messageService;
            _openAIQuestionService = openAIQuestionService;
            _audioRecordService = audioRecordService;
        }
        private void InitializeControls()
        {

            this.Invoke((MethodInvoker)delegate
            {
                cmbCategory.Items.Clear();
                foreach (var category in _categories ?? Array.Empty<Category>())
                {
                    cmbCategory.Items.Add(category);
                }
            });
        }
        private void AddNewQuestionForm_Load(object sender, EventArgs e)
        {
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
            InitializeControls();
            btnSave.Enabled = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_category is not null &&
                !string.IsNullOrWhiteSpace(txtQuestion.Text) &&
                !string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                var newQuestion = new QuestionModel
                {
                    Category = _category,
                    Question = txtQuestion.Text,
                    Answer = txtAnswer.Text
                };
                var dialog = _messageService.ShowCustomMessage("Save this question?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    await _commandService.QuestionRepository.AddAsync(newQuestion);
                    txtAnswer.Clear();
                    btnSave.Enabled = false;
                }
                else if (dialog == DialogResult.No)
                {
                    this.Close();
                }

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _category = cmbCategory.SelectedItem as Category;
        }

        private async void btnGpt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                var annotation = $"Answer briefly and in simple language," +
                    " modify important words or bulletpointnames  add bulletpoints. Make the text structured:";
                var answer = await _openAIQuestionService.GetAnswerAsync(txtQuestion.Text + " " + txtComment.Text, annotation);
                txtAnswer.Clear();
                txtAnswer.Text = answer;
            }
        }
        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }


        private async void txtQuestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
                {
                    var annotation = $"Answer briefly and in simple language," +
                    " modify important words or bulletpointnames  add bulletpoints. Make the text structured:";
                    var answer = await _openAIQuestionService.GetAnswerAsync(txtQuestion.Text + " " + txtComment.Text, annotation);
                    txtAnswer.Clear();
                    txtAnswer.Text = answer;
                }
            }
            else if (e.KeyChar == '\\')
            {
                var strArr = txtQuestion.Text.Split('\r', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strArr)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        var annotation = $"Answer briefly and in simple language," +
                  " modify important words or bulletpointnames  add bulletpoints. Make the text structured:";
                        var answer = await _openAIQuestionService.GetAnswerAsync(txtQuestion.Text + " " + txtComment.Text, annotation);



                        if (_category is not null &&
                            !string.IsNullOrWhiteSpace(answer))
                        {
                            txtAnswer.Clear();
                            txtAnswer.Text = answer;
                            var newQuestion = new QuestionModel
                            {
                                Category = _category,
                                Question = item,
                                Answer = answer
                            };
                            await _commandService.QuestionRepository.AddAsync(newQuestion);
                            Debug.WriteLine(newQuestion);
                            await Task.Delay(700);
                        }
                    }
                }
            }
        }

        private async void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            var conStr = string.Empty;
            if (e.KeyCode == Keys.Menu && Clipboard.ContainsText())
            {
                conStr = $"Provide a response from an applicant for the Dotnet developer position based on this info: \n {BaseInfo.ResumeSummary()}";
                txtQuestion.Clear();
                txtQuestion.Text = Clipboard.GetText();
                var answer = await _openAIQuestionService.GetAnswerAsync(Clipboard.GetText() + " " + txtComment.Text, conStr);
                txtAnswer.Clear();
                txtAnswer.Text = answer;
            }
            if (e.KeyCode == Keys.Oem3 && Clipboard.ContainsText())
            {
                conStr = $"Write a method in {cmbLang.Text}, avoiding LINQ , ordering and built-in methods if possible, no text needed," +
                   $" just code. Comment each code line Remember about optimization and algorithmic complexity:";
                txtQuestion.Clear();
                txtQuestion.Text = Clipboard.GetText();
                var answer = await _openAIQuestionService.GetGeneratedCodeAsync(Clipboard.GetText() + " " + txtComment.Text, conStr);
                txtAnswer.Clear();
                txtAnswer.Text = answer;
            }
        }

        private void txtQuestion_MouseEnter(object sender, EventArgs e)
        {
            txtQuestion.Focus();
        }


        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private string InitDirectory()
        {
            var path = Path.Combine("C:\\Users\\troki\\Desktop\\tem1");
            var fileName = "rec.mp3";
            var fullPath = Path.Combine(path, fileName);
            if (Directory.Exists(path))
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                Directory.Delete(path);
            }

            Directory.CreateDirectory(path);

            return fullPath;
        }


        private void RemoveDirectory()
        {
            var path = Path.Combine("C:\\Users\\troki\\Desktop\\tem1");
            var fileName = "rec.mp3";
            var fullPath = Path.Combine(path, fileName);
            if (Directory.Exists(path))
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                Directory.Delete(path);
            }
        }
        string _filePath = string.Empty;
        private void btnRec_MouseDown(object sender, MouseEventArgs e)
        {
            btnRec.Text = "Record...";
            _filePath = InitDirectory();
            _audioRecordService.StartRecordMicrofhoneAsync();
        }

        private async void btnRec_MouseUp(object sender, MouseEventArgs e)
        {
            btnRec.Text = "Saved...";

            var responce = await _audioRecordService.StopRecordMicrofhoneAsync(_filePath);
            if (!string.IsNullOrEmpty(responce))
            {
                Clipboard.SetText(responce);
                txtQuestion.Text = responce;
                btnRec.Text = "Rec";
            }
            else
            {
                btnRec.Text = "!!!";
            }
            RemoveDirectory();
            btnRec.Text = "Rec";
        }

        private async void btnSyRecord_MouseDown(object sender, MouseEventArgs e)
        {
            btnSyRecord.Text = "Record..";
            _filePath = InitDirectory();
            await _audioRecordService.StartRecordingSpeakerAsync(_filePath);
        }

        private async void btnSyRecord_MouseUp(object sender, MouseEventArgs e)
        {
            btnSyRecord.Text = "Saved..";
            var responce = await _audioRecordService.StopRecordingSpeakerAsync(_filePath);
            if (!string.IsNullOrEmpty(responce))
            {
                Clipboard.SetText(responce);
                txtQuestion.Text = responce;
            }
            RemoveDirectory();
            btnSyRecord.Text = "Rec1";
        }




    }
}

