namespace InterviewHelper.Core.Models.DTOs
{
    public class OpenAIModelResponce
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Choice[] choices { get; set; }
        public Usage usage { get; set; }
        public object system_fingerprint { get; set; }
    }

    
}
