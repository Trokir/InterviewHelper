

namespace InterviewHelper.Core.Models
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
    }
}
