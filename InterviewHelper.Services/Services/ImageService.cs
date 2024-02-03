using InterviewHelper.Core.Models;
using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos.Interfaces;

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
        private readonly IImageEntityRepository _imageEntityRepository;
        public ImageService(IImageEntityRepository imageEntityRepository)
        {
            _imageEntityRepository = imageEntityRepository;
        }

        public async Task DeleteImageAsync(ImageEntity entity)
        {
            await _imageEntityRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ImageEntity>> GetAllEntitiesAsync()
        {
            var result = await _imageEntityRepository.GetAllAsync();
            return result;
        }
        public async Task<ImageEntity> GetImageEntityById(int id)
        {
            var result = await _imageEntityRepository.GetByIdAsync(id);
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

                await _imageEntityRepository.AddAsync(pngFile);
            }
            catch (Exception ex)
            {
            }
        }


    }
}
