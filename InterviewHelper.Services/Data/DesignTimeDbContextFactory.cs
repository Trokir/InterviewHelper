using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InterviewHelper.Services.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<QuestionDbContext>
    {
        public QuestionDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<QuestionDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new QuestionDbContext(optionsBuilder.Options);
        }
    }
}
