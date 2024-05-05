using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;
using InterviewHelper.Core.Config;
using Microsoft.Extensions.Options;
using InterviewHelper.Services.Repos.Interfaces;
using InterviewHelper.Services.Repos;
using InterviewHelper.Services.Data;
using Microsoft.EntityFrameworkCore;
using InterviewHelper.Services;
using InterviewHelper.Forms;
using InterviewHelper.FormServices;
using InterviewHelper.Services.Services;
using System.Threading.Tasks;

static class Program
{
    public static IConfiguration _configuration { get; private set; }
    public static IServiceProvider ServiceProvider { get; private set; }
    public static IHost AppHost { get; private set; }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        AppHost = CreateHostBuilder().Build();
        ServiceProvider = AppHost.Services;

        // Run the background service host
        Task.Run(() => AppHost.RunAsync());

        // Resolve the main form using DI and run the application
        using (var scope = ServiceProvider.CreateScope())
        {
            var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }

    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                ConfigureServices(services);
            });

    private static void ConfigureServices(IServiceCollection services)
    {
        // Bind settings
        var settings = new AppViewConfiguration();
        _configuration.GetSection("AppViewConfiguration").Bind(settings);
        services.AddSingleton(Options.Create(settings))
            .AddSingleton(settings)
            .AddTransient<IQuestionRepository, QuestionRepository>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddScoped<QuestionDbContext>()
            .AddDbContext<QuestionDbContext>(opt => opt.UseSqlServer(settings.DefaultConnection))
            .AddHttpClient()
            .AddHostedService<WindowsBackgroundService>()
            // Add other services
            .AddScoped<MainForm>()
            .AddTransient<AddNewCategoryForm>()
            .AddTransient<IQuestionFormFactory, QuestionFormFactory>()
            .AddTransient<IMessageService, MessageService>()
            .AddTransient<IOpenAIQuestionService, OpenAIQuestionService>()
            .AddTransient<IMongoDbService, MongoDbService>()
            .AddTransient<IAudioRecordService, AudioRecordService>();
    }
}
