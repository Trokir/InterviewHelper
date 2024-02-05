using InterviewHelper.Core.Models.DTOs;

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