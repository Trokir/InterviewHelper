using InterviewHelper.Core.Models;
using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace InterviewHelper.Services.Repos
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuestionDbContext _dbContext;
        public QuestionRepository(QuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(QuestionModel entity)
        {
            await _dbContext.QuestionModels.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(QuestionModel entity)
        {
            _dbContext.QuestionModels.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRangeAsync(Expression<Func<QuestionModel, bool>> predicate)
        {
            var list = await _dbContext.QuestionModels.Where(predicate).ToListAsync().ConfigureAwait(false);
            _dbContext.QuestionModels.RemoveRange(list);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<QuestionModel> FindAsync(Expression<Func<QuestionModel, bool>> predicate)
        {
            return await _dbContext.QuestionModels.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<QuestionModel>> GetAllAsync()
        {
            return await _dbContext.QuestionModels.ToListAsync();
        }

        public async Task<IEnumerable<QuestionModel>> GetAllAsync(Expression<Func<QuestionModel, bool>> predicate)
        {
            return await _dbContext.QuestionModels.Where(predicate).ToListAsync();
        }

        public async Task<QuestionModel> GetByIdAsync(int id)
        {
            var entity = await _dbContext.QuestionModels.FindAsync(id);
            return entity ?? new QuestionModel();
        }

        public async Task UpdateAsync(QuestionModel entity)
        {
            _dbContext.QuestionModels.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateListAsync(IEnumerable<QuestionModel> entities)
        {
            _dbContext.QuestionModels.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
