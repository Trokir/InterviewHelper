using InterviewHelper.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace InterviewHelper.Services.Data
{
    public class QuestionDbContext : DbContext
    {
        public QuestionDbContext(DbContextOptions<QuestionDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QuestionModel> QuestionModels { get; set; }
    }
}
