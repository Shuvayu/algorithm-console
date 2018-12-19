using AlgoIApplication;
using System;
using System.Collections.Generic;

namespace AlgoApplication.Strings
{
    /// <summary>
    /// Implement an algorithm to determine if a string has all unique characters
    /// What if you can not use additional data structures
    /// </summary>
    public class UniqueStringCharacters : IAlgorithm
    {
        // With Dictionary
        private static bool CheckWithDictionary(string givenString)
        {
            var characterDictionary = new Dictionary<char, int>();

            for (int i = 0; i < givenString.Length; i++)
            {
                if (characterDictionary.ContainsKey(givenString[i]))
                {
                    return false;
                }
                else
                {
                    characterDictionary.Add(givenString[i], i);
                }
            }
            return true;

        }

        private static bool CheckWithBoolArray(string givenString)
        {
            var booleanArray = new bool[256];
            for (int i = 0; i < givenString.Length; i++)
            {
                var character = givenString[i];
                if (booleanArray[character])
                {
                    return false;
                }
                else
                {
                    booleanArray[character] = true;
                }
            }
            return true;
        }

        public void Run()
        {
            Console.WriteLine("Enter the string to test for unique characters");
            var givenString = Console.ReadLine();

            var randomAlgo = new Random();
            var selectedAlgo = randomAlgo.Next(1, 2);
            Console.WriteLine($" Algorithm selected : {selectedAlgo}");
            var checkedResult = selectedAlgo == 1 ? CheckWithBoolArray(givenString) : CheckWithDictionary(givenString);

            if (checkedResult)
            {
                Console.WriteLine("The provided string has unique characters.");
            }
            else
            {
                Console.WriteLine("The provided string doesnt have unique characters.");
            }
            Console.Write(Environment.NewLine);
        }
    }
}
