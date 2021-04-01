using System;
using Microsoft.Extensions.Configuration;

namespace Izzy.OptionsPattern.Console1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Console.WriteLine($"TimeZoneOffset = {cfg["TimezoneOffset"]}");
        }
    }
}