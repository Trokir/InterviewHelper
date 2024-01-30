

namespace InterviewHelper.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<QuestionModel> Questions { get; set; }

    }
}
