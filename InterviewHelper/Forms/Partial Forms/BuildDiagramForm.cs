using InterviewHelper.Core.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Forms
{
    public partial class MainForm:Form
    {


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
