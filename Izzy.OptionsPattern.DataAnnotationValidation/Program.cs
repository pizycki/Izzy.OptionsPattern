using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Izzy.OptionsPattern.ConfigureAndValidate
{
    class AppSettings
    {
        public int TimeZoneOffset { get; set; }

        [Required] public string Foobar { get; set; }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //.AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services
                .AddOptions<AppSettings>()
                .Bind(cfg)
                .ValidateDataAnnotations();
            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;

            Console.WriteLine($"TimeZoneOffset = {appSettings.TimeZoneOffset}");
            Console.WriteLine($"Foobar         = {appSettings.Foobar}");
        }
    }
}