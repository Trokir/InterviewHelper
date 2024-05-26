using InterviewHelper.Core.Helper;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Forms
{
    public partial class MainForm : Form
    {


        private void panelHidden_MouseMove(object sender, MouseEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                if (!text.Contains(DiagramHelper.AddInfo))
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(text);
                    sb.AppendLine("  based on this recomendations:\n");
                    sb.AppendLine(DiagramHelper.AddInfo);
                    Clipboard.Clear();
                    Clipboard.SetText(sb.ToString());
                    Debug.Write(sb.ToString());
                }
            }
        }
    }
}
