using InterviewHelper.Core.Helper;
using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace InterviewHelper.Forms
{
    public partial class AddNewQuestionForm : Form
    {
        private readonly IUnitOfWork _commandService;
        private readonly IEnumerable<Category> _categories;
        private readonly IMessageService _messageService;
        private readonly IOpenAIQuestionService _openAIQuestionService;
        private Category _category;

        private WasapiLoopbackCapture capture;
        private WaveFileWriter writer;
        private bool isRecording;

        public AddNewQuestionForm(
            IEnumerable<Category> categories,
            IUnitOfWork commandService,
          IMessageService messageService,
          IOpenAIQuestionService openAIQuestionService)
        {
            InitializeComponent();
            _categories = categories;
            _commandService = commandService;
            _messageService = messageService;
            _openAIQuestionService = openAIQuestionService;
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
            _filePath = InitDirectory();
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
        }

        private async void btnRec_MouseUp(object sender, MouseEventArgs e)
        {
            record($"save recsound {_filePath}", "", 0, 0);
            record("close recsound", "", 0, 0);
            var responce = await _openAIQuestionService.GetTextFromVoice(_filePath);

            Clipboard.SetText(responce ?? " ");
            txtQuestion.Text = responce ?? " ".ToString();

            RemoveDirectory();

        }

        private void btnSyRecord_MouseDown(object sender, MouseEventArgs e)
        {
            // Start recording only if it is not already recording
            if (!isRecording)
            {
                _filePath = InitDirectory();
                // Get the default loopback device
                var device = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

                // Create a capture object
                capture = new WasapiLoopbackCapture(device);

                // Set the format to 16 bit PCM
                capture.WaveFormat = new WaveFormat(44100, 16, 2);

                // Create a writer to save the captured data
                writer = new WaveFileWriter(_filePath, capture.WaveFormat);

                // Register the event handler
                capture.DataAvailable += Capture_DataAvailable;
                capture.RecordingStopped += Capture_RecordingStopped;

                // Start capturing
                capture.StartRecording();

                // Change the recording state
                isRecording = true;
            }
        }

        private void btnSyRecord_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop recording only if it is already recording
            if (isRecording)
            {
                // Stop capturing
                capture.StopRecording();

                // Dispose the capture object
                capture.Dispose();
                capture = null;

                // Dispose the writer object
                writer.Dispose();
                writer = null;



                // Change the recording state
                isRecording = false;
            }
        }
        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Write the captured data to the file
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private async void Capture_RecordingStopped(object sender, StoppedEventArgs e)
        {
            var responce = await _openAIQuestionService.GetTextFromVoice(_filePath);

            Clipboard.SetText(responce ?? " ");
            txtQuestion.Text = responce ?? " ".ToString();

            RemoveDirectory();
        }
    }
}

