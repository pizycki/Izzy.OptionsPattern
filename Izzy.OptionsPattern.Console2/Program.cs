using System;
using Microsoft.Extensions.Configuration;

namespace Izzy.OptionsPattern.Console2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.dev.json", optional: true)
                .AddJsonFile("appsettings.stage.json", optional: true)
                .Build();

            /*
             * The configuration is looked up in reverse order the configuration source have been registered.
             *
             * 1. appsettings.stage.json
             * 2. appsettings.dev.json
             * 3. appsettings.json
             */
            
            Console.WriteLine($"TimeZoneOffset = {cfg["TimezoneOffset"]}");
        }
    }
}