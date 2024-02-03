using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos.Interfaces;

namespace InterviewHelper.Services.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IQuestionRepository QuestionRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        public IImageEntityRepository ImageEntityRepository { get; }

        private readonly QuestionDbContext _dbContext;

        public UnitOfWork(QuestionDbContext dbContext,
            IQuestionRepository questionRepository,
            ICategoryRepository categoryRepository,
            IImageEntityRepository imageEntityRepository)
        {
            _dbContext = dbContext;
            CategoryRepository = categoryRepository;
            QuestionRepository = questionRepository;
            ImageEntityRepository = imageEntityRepository;
        }
        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
