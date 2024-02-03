using InterviewHelper.Core.Models;
using InterviewHelper.Services.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tensorflow.IO;

namespace InterviewHelper.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly QuestionDbContext _questionDbContext;

        public ImageService(QuestionDbContext questionDbContext)
        {
            _questionDbContext = questionDbContext;
        }

        public async Task<IEnumerable<ImageEntity>> GetAllEntitiesAsync()
        {
            var result = await _questionDbContext.ImageEntities.ToListAsync();
            return result;
        }
        public async Task<ImageEntity> GetImageEntityById(int id)
        {
            var result = await _questionDbContext.ImageEntities.FindAsync(id);
            return result ?? new ImageEntity();
        }
        public OpenFileDialog  SelectAndSavePngFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG Files (*.png)|*.png",
                Title = "Select a PNG File"
            };

           return openFileDialog;
        }

        public async Task SavePngFileContentToDb(string filePath, string fileName)
        {
            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);

                var pngFile = new ImageEntity
                {
                    FileName = fileName,
                    Content = fileContent
                };

                await _questionDbContext.ImageEntities.AddAsync(pngFile);
                await _questionDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }


    }
}
