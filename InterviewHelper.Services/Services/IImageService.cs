using InterviewHelper.Core.Models.DTOs;

namespace InterviewHelper.Services.Services
{
    public interface IImageService
    {
        Task SavePngFileContentToDb(string filePath, string fileName);
        OpenFileDialog SelectAndSavePngFile();
        Task<IEnumerable<ImageEntity>> GetAllEntitiesAsync();
        Task<ImageEntity> GetImageEntityById(int id);
        Task DeleteImageAsync(ImageEntity entity);
    }
}