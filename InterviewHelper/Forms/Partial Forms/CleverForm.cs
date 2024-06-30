using InterviewHelper.Core.Helper;
using InterviewHelper.Core.Models;
using InterviewHelper.Forms;

using System.Windows.Forms;

using Tesseract;
namespace InterviewHelper.Forms
{
    public partial class MainForm : Form
    {

        private async void btnProps_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                toolStripStatusLabel1.Text = "Diag pressed";
                var answer = await _openAIQuestionService.GetGeneratedAnswerAsync($"{_textEnvironment.DiagPrompt}{txtxAnswer.Text}", 0.7F);
                txtxAnswer.Clear();
                txtxAnswer.Text = answer;
                toolStripStatusLabel1.Text = "Rewrited Answer reseived";
            }
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
        private void txtxAnswer_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        private async void txtQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {

            }
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



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
            toolStripStatusLabel1.Text = "Recording...";
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
            toolStripStatusLabel1.Text = "Saving...";
            var responce = await _audioRecordService.StopRecordMicrofhoneAsync(_filePath);
            if (!string.IsNullOrEmpty(responce))
            {
                Clipboard.SetText(responce);
                txtQuestion.Text = responce;
                btnRec.Text = "Rec";
                toolStripStatusLabel1.Text = "Saved";
            }
            else
            {
                btnRec.Text = "!!!";
                toolStripStatusLabel1.Text = "Filed";
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
            toolStripStatusLabel1.Text = "Recording...";
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
            toolStripStatusLabel1.Text = "Saving..";
            var responce = await _audioRecordService.StopRecordingSpeakerAsync(_filePath);
            if (!string.IsNullOrEmpty(responce))
            {
                Clipboard.SetText(responce);
                txtQuestion.Text = responce;
                toolStripStatusLabel1.Text = "Saved";
            }
            RemoveDirectory();
            btnSyRecord.Text = "Rec1";
            toolStripStatusLabel1.Text = "";
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtQuestion.SelectionLength > 0)
            {
                var translation = await _openAIQuestionService.GetTranslatedTest(txtQuestion.SelectedText.Trim(), "en", "ru");
                toolTipClever.SetToolTip(txtQuestion, translation);
            }
            else
            {
                toolTipClever.SetToolTip(txtQuestion, "");

            }
        }
        private string InitDirectory()
        {
            string path, fullPath;
            CleanDirectory(out path, out fullPath);

            Directory.CreateDirectory(path);

            return fullPath;
        }

        private static void CleanDirectory(out string path, out string fullPath)
        {
            string tempPath = Path.GetTempPath();
            path = Path.Combine(tempPath, "temp");
            var fileName = "rec.mp3";
            fullPath = Path.Combine(path, fileName);
            if (Directory.Exists(path))
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                Directory.Delete(path);
            }
        }

        private void RemoveDirectory()
        {
            string path, fullPath;
            CleanDirectory(out path, out fullPath);
        }
        private void SaveImageToFile(Image image)
        {
            string tempPath = Path.GetTempPath();
            var path = Path.Combine(tempPath, "temp");
            string filePath = Path.Combine(path, "image.jpg");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                var tessPath = "E:\\Projects\\InterviewHelper\\InterviewHelper.Core\\tessdata\\";
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




        //"SimpleA";
        // "CodeA";
        // "CreativeA";
        // "LoopA";
        // "Paste";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void menuItem_Click(object sender, EventArgs e)
        {
            var conStr = string.Empty;
            var menuItem = (ToolStripItem)sender;
            var question = string.Empty;
            switch (menuItem.Name)
            {
                case "Simple":
                    if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
                    {
                        toolStripStatusLabel1.Text = "Enter pressed";
                        var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(txtQuestion.Text + " " + txtComment.Text, _textEnvironment.BaseAnswer, 0.7F);
                        txtxAnswer.Clear();
                        txtxAnswer.Text = answer;
                        toolStripStatusLabel1.Text = "Answer reseived";
                    }
                    return;
                case "CreativeA":
                    toolStripStatusLabel1.Text = "Creative pressed";
                    conStr = $"{_textEnvironment.CommonAnswer} \n {BaseInfo.ResumeSummary()}";
                    question = txtQuestion.Text + " " + txtComment.Text;
                    await GetResultAsync(conStr, question, 0.7F);
                    toolStripStatusLabel1.Text = "Creative responce";
                    return;
                case "CreativeAB":
                    toolStripStatusLabel1.Text = "Creative from buffer pressed";
                    conStr = $"{_textEnvironment.CommonAnswer} \n {BaseInfo.ResumeSummary()}";
                    txtQuestion.Clear();
                    txtQuestion.Text = Clipboard.GetText();
                    question = Clipboard.GetText() + " " + txtComment.Text;
                    await GetResultAsync(conStr, question, 0.7F);
                    toolStripStatusLabel1.Text = "Creative from buffer responce";
                    return;
                case "LoopA":
                    toolStripStatusLabel1.Text = "Looping code questions";
                    var strArr = txtQuestion.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    var poolList = new HashSet<QuestionModel>();
                    await foreach (var model in _openAIQuestionService.GetPoolOfAnswersAsync(strArr, txtComment.Text, _textEnvironment.BaseAnswer, _category, 0.7F))
                    {
                        txtxAnswer.Clear();
                        txtxAnswer.Text = $"Answer: {model.Answer}";
                        txtQuestion.Clear();
                        txtQuestion.Text = $"Question: {model.Question}";
                        poolList.Add(model);
                    }
                    txtxAnswer.Clear();
                    txtQuestion.Clear();
                    var dialog = _messageService.ShowCustomMessage("All answers are ready to save to DB. \n Continue?", "Save Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        await _commandService.QuestionRepository.AddRangeAsync(poolList);
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Cancelled";
                        _messageService.ShowMessage("Save operation has been cancelled", "Abort");
                    }
                    return;
                case "LoopCode":
                    toolStripStatusLabel1.Text = "Looping questions";
                    strArr = txtQuestion.Text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    poolList = new HashSet<QuestionModel>();
                    await foreach (var model in _openAIQuestionService.GetPoolOfAnswersAsync(strArr, $" {cmbLang.Text}  programming language", _textEnvironment.CodingAnswer, _category, 0.3F))
                    {
                        txtxAnswer.Clear();
                        txtxAnswer.Text = $"Answer: {model.Answer}";
                        txtQuestion.Clear();
                        txtQuestion.Text = $"Question: {model.Question}";
                        poolList.Add(model);
                    }
                    txtxAnswer.Clear();
                    txtQuestion.Clear();
                    dialog = _messageService.ShowCustomMessage("All answers are ready to save to DB. \n Continue?", "Save Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        await _commandService.QuestionRepository.AddRangeAsync(poolList);
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Cancelled";
                        _messageService.ShowMessage("Save operation has been cancelled", "Abort");
                    }
                    return;
                case "CodeA":
                    toolStripStatusLabel1.Text = "code pressed";
                    conStr = $"{_textEnvironment.CodingAnswer} {cmbLang.Text}  programming language";

                    question = txtQuestion.Text + " " + txtComment.Text;
                    await GetResultAsync(conStr, question);
                    toolStripStatusLabel1.Text = "code answer";
                    return;
                case "CodeAB":
                    toolStripStatusLabel1.Text = "code from buffer pressed";
                    conStr = $"{_textEnvironment.CodingAnswer} {cmbLang.Text}  programming language";
                    txtQuestion.Clear();
                    txtQuestion.Text = Clipboard.GetText();
                    question = txtQuestion.Text + " " + txtComment.Text;
                    await GetResultAsync(conStr, question);
                    toolStripStatusLabel1.Text = "code from buffer answer";
                    return;
                case "Paste":
                    if (Clipboard.ContainsText())
                    {
                        txtQuestion.Text = Clipboard.GetText();
                    }
                    return;
                default:

                    break;

            }
            toolStripStatusLabel1.Text = "";
        }

        private async Task GetResultAsync(string conStr, string question, float temperature = 0.3F)
        {
            var answer = await _openAIQuestionService.GetGeneratedAnswerAsync(question, conStr, temperature);
            txtxAnswer.Clear();
            txtxAnswer.Text = answer;
        }
    }
}
