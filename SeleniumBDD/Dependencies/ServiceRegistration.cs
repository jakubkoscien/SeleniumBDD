using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SeleniumBDD.Config;
using SeleniumBDD.Drivers;
using SeleniumBDD.Pages;

namespace SeleniumBDD.Dependencies
{
    public class ServiceRegistration
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            // Read appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Config\\appsettings.json")
                .Build();

            // Register TestSettings
            var testSettings = config.Get<TestSettings>();
            services.AddSingleton(testSettings);

            // Driver Factory
            services.AddScoped<IDriverFactory, DriverFactory>();

            // WebDriver
            services.AddScoped<IWebDriver>(provider =>
            {
                var factory = provider.GetRequiredService<IDriverFactory>();
                return factory.Create();
            });

            // Pages
            services.AddScoped<LoginPage>();

            return services;
        }
    }
}
