using InterviewHelper.Core.Config;
using InterviewHelper.Core.Models;

using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;

using SharpCompress.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Services.Services
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<PngImage> _images;
        private readonly AppViewConfiguration _appViewConfiguration;
        public MongoDbService(IOptions<AppViewConfiguration> options)
        {
            _appViewConfiguration = options.Value;
            var client = new MongoClient(_appViewConfiguration.ConnectionString);
            var database = client.GetDatabase(_appViewConfiguration.DatabaseName);
            _images = database.GetCollection<PngImage>("PngFiles");
        }

        public async Task<List<PngImage>> GetAllImagesAsync()
        {
            return await _images.Find(image => true).ToListAsync();
        }
        public OpenFileDialog SelectAndSavePngFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png",
                Title = "Select a PNG File"
            };

            return openFileDialog;
        }
        public async Task<PngImage> GetImageByIdAsync(ObjectId id)
        {
            var filter = Builders<PngImage>.Filter.Eq(image => image.Id, id);
            return await _images.Find(filter).FirstOrDefaultAsync();
        }
      
        public async Task CreateImageAsync(string filePath, string fileName)
        {
            byte[] fileContent = await File.ReadAllBytesAsync(filePath);
            var image = new PngImage
            {
                ImageData = fileContent,
                Description = fileName
            };
            await _images.InsertOneAsync(image);
        }
        public async Task UpdateImageAsync(ObjectId id, PngImage updatedImage)
        {
            var filter = Builders<PngImage>.Filter.Eq(image => image.Id, id);
            var update = Builders<PngImage>.Update
                .Set(image => image.Description, updatedImage.Description)
                .Set(image => image.ImageData, updatedImage.ImageData);

            await _images.UpdateOneAsync(filter, update);
        }
        public async Task DeleteImageAsync(ObjectId id)
        {
            var filter = Builders<PngImage>.Filter.Eq(image => image.Id, id);
            await _images.DeleteOneAsync(filter);
        }

    }
}
