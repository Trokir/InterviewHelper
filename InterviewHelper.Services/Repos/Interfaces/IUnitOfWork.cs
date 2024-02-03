namespace InterviewHelper.Services.Repos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IQuestionRepository QuestionRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IImageEntityRepository ImageEntityRepository { get; }
        Task<int> Complete();
    }
}
