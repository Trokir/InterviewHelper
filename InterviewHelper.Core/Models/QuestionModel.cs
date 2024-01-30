namespace InterviewHelper.Core.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
