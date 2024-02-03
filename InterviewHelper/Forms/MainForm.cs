using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;
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
        private readonly AppViewConfiguration _config;
        private bool _isPressed;
        public MainForm(IUnitOfWork commandService,
            IQuestionFormFactory formFactory,
            IMessageService messageService,
            IServiceProvider serviceProvider,
            IOpenAIQuestionService openAIQuestionService,
            IAudioRecordService audioRecordService,
            IOptions<AppViewConfiguration> options)
        {
            _config = options.Value;
            _commandService = commandService;
            _formFactory = formFactory;
            InitializeComponent();
            _messageService = messageService;
            _serviceProvider = serviceProvider;
            _openAIQuestionService = openAIQuestionService;
            _audioRecordService = audioRecordService;
        }



        private async void MainForm_Load(object sender, EventArgs e)
        {
            await InitializeControls(_commandService);
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
            await Task.Run(() =>
            {
                RunBatchFile("processKiller.bat");
                RunBatchFile("diagram.bat");

            });
        }
        private async Task InitializeControls(IUnitOfWork commandService)
        {
            _categories = (await commandService
                .CategoryRepository.GetAllAsync()).OrderBy(x => x.Name);
            _questions = _categories.SelectMany(c => c.Questions);
            this.Invoke((MethodInvoker)delegate
            {

                cmbCategory.Items.Clear();
                foreach (var category in _categories)
                {
                    cmbCategory.Items.Add(category);
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
            await InitializeControls(_commandService);
            cmbCategory.Text = "";
            txtSearch.Clear();
            dgvQuestions.DataSource = null;
            txtAnswer.Clear();
            dgvQuestions.Refresh();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var form = _formFactory.CreateNewQuestionForm(_categories, _commandService,
                _messageService, _openAIQuestionService, _audioRecordService, _config);
            form.Show();
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

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<TextFromPictuireForm>();
            form.Show();

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

        private void btnDiagram_Click(object sender, EventArgs e)
        {

            var form = _serviceProvider.GetRequiredService<CreateDiagramForm>();
            form.Show();
        }

        private void RunBatchFile(string fileName)
        {

            var process = new Process();
            var startinfo = new ProcessStartInfo(@$"{_config.WebWorkingDirectory}{fileName}", "\"1st_arg\" \"2nd_arg\" \"3rd_arg\"");
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            process.StartInfo = startinfo;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += (sender, argsx) => Debug.WriteLine(argsx.Data); // do whatever processing you need to do in this handler
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
    }
}