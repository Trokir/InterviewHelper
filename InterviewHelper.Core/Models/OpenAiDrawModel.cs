using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Core.Models
{
public class OpenAiDrawModel
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int n { get; set; }
        public string size { get; set; }
    }
}
