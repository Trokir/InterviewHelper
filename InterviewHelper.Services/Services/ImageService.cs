﻿using InterviewHelper.Core.Models.DTOs;
using InterviewHelper.Services.Repos.Interfaces;

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
        public OpenFileDialog SelectAndSavePngFile()
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
            catch (Exception)
            {
            }
        }


    }
}
