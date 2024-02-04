using InterviewHelper.Core.Models;

using MongoDB.Bson;

namespace InterviewHelper.Services.Services
{
    public interface IMongoDbService
    {
        Task<List<PngImage>> GetAllImagesAsync();
        Task<PngImage> GetImageByIdAsync(ObjectId id);
        Task CreateImageAsync(string filePath, string fileName);
        Task DeleteImageAsync(ObjectId id);
        Task UpdateImageAsync(ObjectId id, PngImage updatedImage);
        OpenFileDialog SelectAndSavePngFile();
    }
}