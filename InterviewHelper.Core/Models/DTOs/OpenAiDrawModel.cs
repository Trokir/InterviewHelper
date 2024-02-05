namespace InterviewHelper.Core.Models.DTOs
{
    public class OpenAiDrawModel
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int n { get; set; }
        public string size { get; set; }
    }
}
