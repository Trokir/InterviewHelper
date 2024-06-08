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
                    sb.AppendLine(DiagramHelper.AddInfo);
                    sb.AppendLine(text);
                    Clipboard.Clear();
                    Clipboard.SetText(sb.ToString());
                    Debug.Write(sb.ToString());
                }
            }
        }
    }
}
