using AlgoIApplication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AlgoConsole
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        private static readonly Assembly AlgoAssembly = Assembly.LoadFrom(nameof(AlgoApplication));

        public static void Main()
        {
            Run();

            Console.ReadKey();
        }

        private static void Run()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            DisplayMenu();

            Console.WriteLine("Program completed");
        }

        private static void DisplayMenu()
        {
            var enteredValue = 0;
            do
            {
                Console.WriteLine("Select an algorithm to run");

                var menuDictionary = CreateMenuDynamically();

                int.TryParse(Console.ReadLine(), out enteredValue);

                if (enteredValue != 0 && menuDictionary.ContainsKey(enteredValue))
                {
                    var executingAlgorithm = menuDictionary[enteredValue];
                    var algoType = GetType(executingAlgorithm);
                    var createdAlgorithmInstance = (IAlgorithm)Activator.CreateInstance(algoType);
                    createdAlgorithmInstance.Run();
                }

            } while (enteredValue != 0);
        }

        private static Dictionary<int, string> CreateMenuDynamically()
        {
            var menuDictionary = new Dictionary<int, string>();
            var index = 1;
            foreach (Type type in AlgoAssembly.GetTypes())
            {
                menuDictionary.Add(index, type.Name);
                index++;
            }

            menuDictionary.Add(0, "Exit");

            foreach (var menuItem in menuDictionary)
            {
                Console.WriteLine($"{menuItem.Key}: {menuItem.Value}");
            }

            return menuDictionary;
        }

        private static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;

            foreach (var assemblyType in AlgoAssembly.GetTypes())
            {
                if (assemblyType.Name == typeName)
                {
                    type = assemblyType;
                    break;
                }
            }
            return type;
        }
    }
}
