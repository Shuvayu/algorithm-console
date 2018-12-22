using AlgoIApplication;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AlgoConsole
{
    public class Menu
    {
        #region Variables and Declarations
        private Assembly _AlgoAssembly;
        private Type[] _Types;


        public Assembly AlgoAssembly
        {
            get
            {
                if (_AlgoAssembly == default(Assembly))
                {
                    _AlgoAssembly = Assembly.LoadFrom(nameof(AlgoApplication));

                }
                return _AlgoAssembly;
            }
        }

        public Type[] AlgoTypes
        {
            get
            {
                if (_Types == default(Type[]))
                {
                    _Types = AlgoAssembly.GetTypes();

                }
                return _Types;
            }
        }
        #endregion

        public void DisplayMenu()
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

        #region Private Methods
        private Dictionary<int, string> CreateMenuDynamically()
        {
            var menuDictionary = new Dictionary<int, string>();
            var index = 1;
            foreach (Type type in AlgoTypes)
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

        private Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;

            foreach (var assemblyType in AlgoTypes)
            {
                if (assemblyType.Name == typeName)
                {
                    type = assemblyType;
                    break;
                }
            }
            return type;
        }
        #endregion
    }
}
