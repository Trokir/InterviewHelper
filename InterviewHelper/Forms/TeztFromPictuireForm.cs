using InterviewHelper.FormServices;
using InterviewHelper.Services.Services;

using Tesseract;

namespace InterviewHelper.Forms
{
    public partial class TeztFromPictuireForm : Form
    {
        private readonly IMessageService _messageService;
        private readonly IOpenAIQuestionService _openAIQuestionService;
        public TeztFromPictuireForm(IMessageService messageService
            , IOpenAIQuestionService openAIQuestionService)
        {
            _openAIQuestionService = openAIQuestionService;
            _messageService = messageService;
            InitializeComponent();

        }



        private void LoadImageFromClipboard()
        {
            if (Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                pcbImage.Image = image;

                SaveImageToFile(image);
            }
            else
            {
                MessageBox.Show("No image in clipboard.");
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
                txtText.Text = page.GetText();
                Clipboard.SetText(txtText.Text);
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

        private void TeztFromPictuireForm_Load(object sender, EventArgs e)
        {
            LoadImageFromClipboard();
        }

        private async void btnAsk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtText.Text))
            {
                var responce = await _openAIQuestionService.GetAnswerAsync(txtText.Text);
                txtAnswer.Text = responce ?? "No data";
            }
        }
    }
}
