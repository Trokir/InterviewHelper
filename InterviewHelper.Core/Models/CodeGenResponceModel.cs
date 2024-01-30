using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InterviewHelper.Core.Models
{

    public class CodeGenResponceModel
    {
            public string id { get; set; }
            public string _object { get; set; }
            public int created { get; set; }
            public string model { get; set; }
            public ChoiceI[] choices { get; set; }
            public Usage1 usage { get; set; }
        }
    [DataContract(Name = "Usage")]
    public class Usage1
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }
        }

    [DataContract(Name = "Choice")]
    public class ChoiceI
        {
            public string text { get; set; }
            public int index { get; set; }
            public object logprobs { get; set; }
            public string finish_reason { get; set; }
        }

    }
