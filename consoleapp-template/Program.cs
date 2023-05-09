using $safeprojectname$.Interfaces;
using $safeprojectname$.Logging;
using $safeprojectname$.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace $safeprojectname$
{
    internal class Program
    {
        private ILogger _logger;
        private Config _config;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting host ...");

            BuildHost()
                .Services
                .GetRequiredService<Program>()
                .Run()
                .GetAwaiter()
                .GetResult();
        }

        public async Task Run()
        {
            // Run program task
            _logger.Info<Program>(_config.ExampleData);
        }

        public Program(ILogger logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

    private static IHost BuildHost()
    {
        return Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
        {
            // register services
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<Config>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var config = configuration.Get<Config>();
                if (config == null) throw new Exception("Failed to retrieve config");
                return config;
            });
            services.AddTransient<Program>();
        })
        .ConfigureAppConfiguration((_, config) =>
        {
            config.AddJsonFile("config.json", optional: true, reloadOnChange: true);
        })
        .Build();
    }

    }
}