using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Izzy.OptionsPattern.Configure
{
    /**
     * Configure extension for IServiceCollection
     * is a shorthand for binding POCO to instances of IConfiguration.
     */
    
    class AppSettings
    {
        public int TimeZoneOffset { get; set; }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<AppSettings>(cfg);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
            Console.WriteLine($"TimeZoneOffset = {appSettings.TimeZoneOffset}");
        }
    }
}