using MongoDB.Bson;


namespace InterviewHelper.Core.Models.DTOs
{
    public class PngImage
    {
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
    }
}
