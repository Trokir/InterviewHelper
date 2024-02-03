using InterviewHelper.Core.Config;
using InterviewHelper.FormServices;

using Microsoft.Extensions.Options;

namespace InterviewHelper.Forms
{
    public partial class CreateDiagramForm : Form
    {
        private readonly AppViewConfiguration _config;
        private readonly IMessageService _messageService;
        public CreateDiagramForm(IOptions<AppViewConfiguration> options,
            IMessageService messageService)
        {
            InitializeComponent();
            _config = options.Value;
            _messageService = messageService;

            webViewDiagram.Source = new Uri(_config.DiagramUrl);


        }



        private void CreateDiagramForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
