using System.Runtime.Serialization;

namespace InterviewHelper.Core.Models.DTOs
{

    public class CodeGenResponceModel
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Choice1[] choices { get; set; }
        public Usage1 usage { get; set; }
        public object system_fingerprint { get; set; }
    }
    [DataContract(Name = "Usage")]
    public class Usage1
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
    [DataContract(Name = "Choice")]
    public class Choice1
    {
        public int index { get; set; }
        public Message message { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }
    [DataContract(Name = " Message")]
    public class Message1
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
