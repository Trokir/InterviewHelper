using InterviewHelper.Core.Config;
using InterviewHelper.Core.Helper;
using InterviewHelper.FormServices;

using Microsoft.Extensions.Options;

using System.Text;

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

        private void panelHidden_MouseMove(object sender, MouseEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                if (!text.Contains(DiagramHelper.AddInfo))
                {
                    var sb = new StringBuilder();
                    sb.Append(text);
                    sb.Append(DiagramHelper.AddInfo);
                    Clipboard.Clear();
                    Clipboard.SetText(sb.ToString());
                }
            }
        }
    }
}
