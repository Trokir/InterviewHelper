using InterviewHelper.Core.Models;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Repos.Interfaces;

namespace InterviewHelper.Forms
{
    public partial class AddNewCategoryForm : Form
    {
        private readonly IMessageService _messageService;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<Category> _categories;
        public AddNewCategoryForm(IUnitOfWork unitOfWork, IMessageService messageService)
        {
            _messageService = messageService;
            _unitOfWork = unitOfWork;
            InitializeComponent();
        }
        private async Task InitializeControls(IUnitOfWork commandService)
        {
            _categories = await commandService
                .CategoryRepository.GetAllAsync();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                var ifExists = _categories.Any(x => x.Name == txtCategory.Text.Trim());
                if (ifExists)
                {
                    _messageService.ShowWarning("This category already exists", "Warning");
                }
                else
                {
                    var category = new Category
                    {
                        Name = txtCategory.Text,
                        Questions = new HashSet<QuestionModel>()
                    };
                    var dialog = _messageService.ShowCustomMessage("Save this category?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        await _unitOfWork.CategoryRepository.AddAsync(category);

                    }
                    else if (dialog == DialogResult.No)
                    {
                        this.Close();
                    }
                    this.Close();
                }
            }
        }

        private async void AddNewCategoryForm_Load(object sender, EventArgs e)
        {
            await InitializeControls(_unitOfWork);
        }
    }
}
