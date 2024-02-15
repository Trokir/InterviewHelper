using InterviewHelper.Core.Helper;
using InterviewHelper.Core.Models;
using InterviewHelper.Forms;

using System.Windows.Forms;

using Tesseract;
namespace InterviewHelper.Forms
{
    public partial class MainForm : Form
    {
        private void InitializeControls()
        {

            this.Invoke((MethodInvoker)delegate
            {
              
            });
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_category is not null &&
                !string.IsNullOrWhiteSpace(txtQuestion.Text) &&
                !string.IsNullOrWhiteSpace(txtxAnswer.Text))
            {
                var newQuestion = new QuestionModel
                {
                    Category = _category,
                    Question = txtQuestion.Text,
                    Answer = txtxAnswer.Text
                };
                toolStripStatusLabel1.Text = "Saving...";
                var dialog = _messageService.ShowCustomMessage("Save this question?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    await _commandService.QuestionRepository.AddAsync(newQuestion);
                    txtxAnswer.Clear();
                    btnSave.Enabled = false;
                    toolStripStatusLabel1.Text = "Saved";
                }
                else if (dialog == DialogResult.No)
                {
                    this.Close();
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _category = cmbxCategory.SelectedItem as Category;
            toolStripStatusLabel1.Text = _category.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnxGpt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                toolStripStatusLabel1.Text = "Asking gpt";
                var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(txtQuestion.Text + " " + txtComment.Text, _textEnvironment.BaseAnswer, 0.7F);
                txtxAnswer.Clear();
                txtxAnswer.Text = answer;
                toolStripStatusLabel1.Text = "done";
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void txtxAnswer_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void txtQuestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
                {
                    toolStripStatusLabel1.Text = "Enter pressed";
                    var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(txtQuestion.Text + " " + txtComment.Text, _textEnvironment.BaseAnswer, 0.7F);
                    txtxAnswer.Clear();
                    txtxAnswer.Text = answer;
                }
            }
            else if (e.KeyChar == '+')
            {
                toolStripStatusLabel1.Text = "Looping questions";
                var strArr = txtQuestion.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var poolList = new HashSet<QuestionModel>();
                await foreach (var model in _openAIQuestionService.GetPoolOfAnswersAsync(strArr, txtComment.Text, _textEnvironment.BaseAnswer, _category))
                {
                    txtxAnswer.Clear();
                    txtxAnswer.Text = $"Answer: {model.Answer}";
                    txtQuestion.Clear();
                    txtQuestion.Text = $"Question: {model.Question}";
                    poolList.Add(model);
                }
                txtxAnswer.Clear();
                txtQuestion.Clear();
                var dialog = _messageService.ShowCustomMessage("All answers are ready to save to DB. \n Continue?", "Sava Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    await _commandService.QuestionRepository.AddRangeAsync(poolList);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Cancelled";
                    _messageService.ShowMessage("Save operation has been cancelled", "Abort");
                }

            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            var conStr = string.Empty;
            if (e.KeyCode == Keys.NumPad1 && Clipboard.ContainsText())
            {
                toolStripStatusLabel1.Text = "NumPad1 pressed";
                conStr = $"{_textEnvironment.CommonAnswer} \n {BaseInfo.ResumeSummary()}";
                txtQuestion.Clear();
                txtQuestion.Text = Clipboard.GetText();
                var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(Clipboard.GetText() + " " + txtComment.Text, conStr, 0.7F);
                txtxAnswer.Clear();
                txtxAnswer.Text = answer;
            }
            if (e.KeyCode == Keys.NumPad2 && Clipboard.ContainsText())
            {
                toolStripStatusLabel1.Text = "NumPad2 pressed";
                conStr = $"{_textEnvironment.CodingAnswer} {cmbLang.Text}";
                txtQuestion.Clear();
                txtQuestion.Text = Clipboard.GetText();
                var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(Clipboard.GetText() + " " + txtComment.Text, conStr);
                txtxAnswer.Clear();
                txtxAnswer.Text = answer;
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void txtQuestion_MouseEnter(object sender, EventArgs e)
        {
            txtQuestion.Focus();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnRec_MouseDown(object sender, MouseEventArgs e)
        {
            btnRec.Text = "Record...";
            _filePath = InitDirectory();
            _audioRecordService.StartRecordMicrofhoneAsync();
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void btnRec_MouseUp(object sender, MouseEventArgs e)
        {
            btnRec.Text = "Saving...";

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
      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void btnSyRecord_MouseDown(object sender, MouseEventArgs e)
        {
            btnSyRecord.Text = "Record..";
            _filePath = InitDirectory();
            await _audioRecordService.StartRecordingSpeakerAsync(_filePath);
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void btnSyRecord_MouseUp(object sender, MouseEventArgs e)
        {
            btnSyRecord.Text = "Saving..";
            var responce = await _audioRecordService.StopRecordingSpeakerAsync(_filePath);
            if (!string.IsNullOrEmpty(responce))
            {
                Clipboard.SetText(responce);
                txtQuestion.Text = responce;
            }
            RemoveDirectory();
            btnSyRecord.Text = "Rec1";
        }
        private void pkbPic_MouseEnter(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                pkbPic.Image = image;

                SaveImageToFile(image);
            }
        }

        private string InitDirectory()
        {
            var path = Path.Combine(_config.TempFilePath);
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
            var path = Path.Combine(_config.TempFilePath);
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
        private void SaveImageToFile(Image image)
        {
            var path = @"C:\\Users\\troki\\Desktop\\temp";
            string filePath = Path.Combine(path, "image.jpg");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                var tessPath = "D:\\Projects\\InterviewHelper\\InterviewHelper.Core\\tessdata\\";
                using var engine = new TesseractEngine(tessPath, "eng", EngineMode.Default);
                using var img = Pix.LoadFromFile(filePath);
                using var page = engine.Process(img);
                var content = page.GetText();
                if (!string.IsNullOrEmpty(content))
                {
                    txtQuestion.Text = content;
                }
                else
                {
                    txtQuestion.Text = "Can't parse";
                }
            }
            if (File.Exists(filePath))
            {
                // If file found, delete it
                File.Delete(filePath);
            }
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }

        }
    }
}
