using InterviewHelper.Core.Models;
using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace InterviewHelper.Services.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuestionDbContext _dbContext;
        public CategoryRepository(QuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Category entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Category> entities)
        {
            await _dbContext.Categories.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(Expression<Func<Category, bool>> predicate)
        {
            var list = await _dbContext.Categories.Where(predicate).ToListAsync().ConfigureAwait(false);
            _dbContext.Categories.RemoveRange(list);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Category> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.Include(x => x.Questions).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _dbContext.Categories.Where(predicate).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Categories.FindAsync(id);
            return entity ?? new Category();
        }

        public async Task UpdateAsync(Category entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateListAsync(IEnumerable<Category> entities)
        {
            _dbContext.Categories.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
