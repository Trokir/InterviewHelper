using InterviewHelper.Core.Models.DTOs;
using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace InterviewHelper.Services.Repos
{
    public class ImageEntityRepository : IImageEntityRepository
    {
        private readonly QuestionDbContext _dbContext;
        public ImageEntityRepository(QuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ImageEntity entity)
        {
            await _dbContext.ImageEntities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ImageEntity entity)
        {
            _dbContext.ImageEntities.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(Expression<Func<ImageEntity, bool>> predicate)
        {
            var list = await _dbContext.ImageEntities.Where(predicate).ToListAsync().ConfigureAwait(false);
            _dbContext.ImageEntities.RemoveRange(list);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<ImageEntity> FindAsync(Expression<Func<ImageEntity, bool>> predicate)
        {
            return await _dbContext.ImageEntities.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<ImageEntity>> GetAllAsync()
        {
            return await _dbContext.ImageEntities.ToListAsync();
        }

        public async Task<IEnumerable<ImageEntity>> GetAllAsync(Expression<Func<ImageEntity, bool>> predicate)
        {
            return await _dbContext.ImageEntities.Where(predicate).ToListAsync();
        }

        public async Task<ImageEntity> GetByIdAsync(int id)
        {
            var entity = await _dbContext.ImageEntities.FindAsync(id);
            return entity ?? new ImageEntity();
        }

        public async Task UpdateAsync(ImageEntity entity)
        {
            _dbContext.ImageEntities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateListAsync(IEnumerable<ImageEntity> entities)
        {
            _dbContext.ImageEntities.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
