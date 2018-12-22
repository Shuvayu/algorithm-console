using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AlgoConsole
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Algorithm Playground";

            Run();

            Console.ReadKey();
        }

        private static void Run()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var menu = new Menu();
            menu.DisplayMenu();

            Console.WriteLine("Program completed");
        }
    }
}
