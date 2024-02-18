using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
using InterviewHelper.Core.Models.DTOs;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System.Data;
using System.Diagnostics;

namespace InterviewHelper.Forms
{

    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _commandService;
        private IEnumerable<Category> _categories;
        private IEnumerable<QuestionModel> _questions;
        private readonly IQuestionFormFactory _formFactory;
        private readonly IOpenAIQuestionService _openAIQuestionService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageService _messageService;
        private readonly IAudioRecordService _audioRecordService;
        private readonly IMongoDbService _mongoDbService;

        private IEnumerable<PngImage> _images;
        private readonly AppViewConfiguration _config;
        private readonly TextEnvironment _textEnvironment;
        private string _filePath = string.Empty;
        private Category _category;
        private bool _isPressed;
        public MainForm(IUnitOfWork commandService,
            IQuestionFormFactory formFactory,
            IMessageService messageService,
            IServiceProvider serviceProvider,
            IOpenAIQuestionService openAIQuestionService,
            IAudioRecordService audioRecordService,
            IOptions<AppViewConfiguration> options,
            IOptions<TextEnvironment> textEnvironment,
            IMongoDbService mongoDbService)
        {
            _config = options.Value;
            _commandService = commandService;
            _formFactory = formFactory;
            InitializeComponent();
            _messageService = messageService;
            _serviceProvider = serviceProvider;
            _openAIQuestionService = openAIQuestionService;
            _audioRecordService = audioRecordService;
            _textEnvironment = textEnvironment.Value;
            _mongoDbService = mongoDbService;
        }



        private async void MainForm_Load(object sender, EventArgs e)
        {
            await InitializeControls(_commandService);
            await InitDiagramForm();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
            cmbxCategory.ValueMember = "Id";
            cmbxCategory.DisplayMember = "Name";
            //this.Invoke(new Action(async () => {
            //    await webViewDiagram.EnsureCoreWebView2Async(null);
            //}));
            await Task.Run(() =>
            {
                RunBatchFile("processKiller.bat");
                RunBatchFile("diagram.bat", _config.BatFilePath);
                webViewDiagram.Source = new Uri(_config.DiagramUrl);
            });

        }
        private async Task InitializeControls(IUnitOfWork commandService)
        {
            _categories = await commandService
                .CategoryRepository.GetAllAsync();
            _questions = _categories.OrderBy(x => x.Name).SelectMany(c => c.Questions);
            this.Invoke((MethodInvoker)delegate
            {

                cmbCategory.Items.Clear();
                foreach (var category in _categories)
                {
                    cmbCategory.Items.Add(category);
                }
                cmbxCategory.Items.Clear();
                foreach (var category in _categories ?? Array.Empty<Category>())
                {
                    cmbxCategory.Items.Add(category);
                }
            });
            cmbCategory.Refresh();

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var category = cmbCategory.SelectedItem as Category;
            IEnumerable<QuestionModel>? questions;

            questions = _categories.Where(x => x.Id == category.Id)
                           .SelectMany(z => z.Questions);

            InitDataGrid(questions);
        }

        private void InitDataGrid(IEnumerable<QuestionModel> questions)
        {
            dgvQuestions.Invoke(new MethodInvoker(() =>
            {
                dgvQuestions.DataSource = null;
                dgvQuestions.Visible = false;
                dgvQuestions.DataSource = questions.ToArray();
                dgvQuestions.Columns[0].Visible = false;
                dgvQuestions.Columns[1].Visible = false;
                dgvQuestions.Columns[3].Visible = false;
                dgvQuestions.Visible = true;
            }));
        }


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await InitializeControls(_commandService);
            cmbCategory.Text = "";
            txtSearch.Clear();
            dgvQuestions.DataSource = null;
            txtAnswer.Clear();
            dgvQuestions.Refresh();
            btnRefresh.Enabled = true;
        }



        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<AddNewCategoryForm>();
            form.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            var row = dgvQuestions.CurrentRow;
            var index = (int)row.Cells[0].Value;
            var model = _questions.FirstOrDefault(x => x.Id == index);
            if (model is not null)
            {
                var form = _formFactory.CreateUpdateQuestionForm(model, _commandService, _messageService);
                form.Show();
            }
            else
            {
                _messageService.ShowError("The question has not been choosed", "Error");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = dgvQuestions.CurrentRow;
            var index = (int)row.Cells[0].Value;
            var model = _questions.FirstOrDefault(x => x.Id == index);
            if (model is not null)
            {
                var form = _formFactory.DeleteQuestionForm(model, _commandService, _messageService);
                form.ShowDialog();
            }
            else
            {
                _messageService.ShowError("The question has not been choosed", "Error");
            }
        }

        private void dgvQuestions_SelectionChanged(object sender, EventArgs e)
        {
            var answer = dgvQuestions.CurrentRow?.Cells[3]?.Value.ToString() ?? string.Empty;
            txtAnswer.Clear();
            txtAnswer.Text = answer;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var data = _questions.ToArray();

            if (txtSearch.Text.Length >= 3)
            {
                if (_isPressed)
                {
                    var filtArr = txtSearch.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var filteredData = data?.Where(c => filtArr.Any(word => c.Question.Contains(word, StringComparison.InvariantCultureIgnoreCase)));
                    InitDataGrid(filteredData);
                    dgvQuestions.Refresh();
                }
                else
                {
                    var filtArr = txtSearch.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var filteredData = data?.Where(c => filtArr.All(word => c.Question.Contains(word, StringComparison.InvariantCultureIgnoreCase)));
                    InitDataGrid(filteredData);
                    dgvQuestions.Refresh();
                }
                _isPressed = false;
            }
            else
            {
                var category = cmbCategory.SelectedItem as Category;
                var questions = _categories.Where(x => x.Id == category?.Id)
                    .SelectMany(z => z.Questions);
                InitDataGrid(questions);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu && Clipboard.ContainsText())
            {
                _isPressed = true;
                txtSearch.Clear();
                txtSearch.Text = Clipboard.GetText().ToLower();

            }
            if (e.KeyCode == Keys.Right)
            {
                dgvQuestions.Focus();
            }

        }

        private void txtSearch_MouseEnter(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void dgvQuestions_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }
        }
        private void RunBatchFile(string fileName, string pathArgument = "")
        {


            var process = new Process();
            var startinfo = new ProcessStartInfo(@$"{_config.WebWorkingDirectory}{fileName}", "\"1st_arg\" \"2nd_arg\" \"3rd_arg\"");
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            startinfo.Arguments = pathArgument;
            process.StartInfo = startinfo;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += (sender, argsx) => Debug.WriteLine(argsx.Data); // do whatever processing you need to do in this handler
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = mainMenutabControl.SelectedIndex;
            if (mainMenutabControl.SelectedIndex == 3)
            {
                webViewDiagram.Refresh();
                webViewDiagram.Source = new Uri(_config.DiagramUrl);
            }

        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            // Ensure TabControl exists and has more than one tab.
            if (mainMenutabControl != null && mainMenutabControl.TabCount > 1)
            {
                // Specifically handle CTRL+Right arrow key combination for next tab.
                if (keyData == (Keys.Control | Keys.Right))
                {
                    int nextTabIndex = mainMenutabControl.SelectedIndex + 1;
                    if (nextTabIndex < mainMenutabControl.TabCount)
                    {
                        mainMenutabControl.SelectedIndex = nextTabIndex;
                    }
                    else
                    {
                        // Optional: Wrap to the first tab.
                        mainMenutabControl.SelectedIndex = 0;
                    }
                    return true; // Key press handled.
                }
                // Specifically handle CTRL+Left arrow key combination for previous tab.
                else if (keyData == (Keys.Control | Keys.Left))
                {
                    int prevTabIndex = mainMenutabControl.SelectedIndex - 1;
                    if (prevTabIndex >= 0)
                    {
                        mainMenutabControl.SelectedIndex = prevTabIndex;
                    }
                    else
                    {
                        // Optional: Wrap to the last tab.
                        mainMenutabControl.SelectedIndex = mainMenutabControl.TabCount - 1;
                    }
                    return true; // Key press handled.
                }
            }

            // For any other keyData conditions, defer to the base class's implementation.
            // This explicitly excludes handling for simple Left and Right arrow key presses without modifiers.
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           var dialog = _messageService.ShowCustomMessage("Are you sure?", "Close program",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                RunBatchFile("processKiller.bat");
            }
        }
    }
}
