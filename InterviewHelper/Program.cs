
using InterviewHelper.Core.Config;
using InterviewHelper.Forms;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Data;
using InterviewHelper.Services.Repos;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace InterviewHelper
{
    static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configure DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Resolve the main form using DI and run the application
            using (var scope = ServiceProvider.CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Bind settings
            var settings = new AppViewConfiguration();

            Configuration.GetSection("AppViewConfiguration").Bind(settings);
            _ = services.AddSingleton(Options.Create(settings));
            services.AddSingleton(settings)
                .AddTransient<IQuestionRepository, QuestionRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>()
                 .AddScoped<QuestionDbContext>();
            services.AddDbContext<QuestionDbContext>(opt =>
            opt.UseSqlServer(settings.DefaultConnection));

            services.AddHttpClient();

            // Add other services
            services.AddScoped<MainForm>();
            services.AddTransient<AddNewCategoryForm>();
            services.AddTransient<IQuestionFormFactory, QuestionFormFactory>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IOpenAIQuestionService, OpenAIQuestionService>();
            services.AddTransient<IMongoDbService, MongoDbService>();
            services.AddTransient<IAudioRecordService, AudioRecordService>();


        }
    }
}