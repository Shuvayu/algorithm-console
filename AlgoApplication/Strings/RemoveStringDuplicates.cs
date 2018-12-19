using AlgoIApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoApplication.Strings
{
    /// <summary>
    /// Part 1: Design an algorithm and write code to remove the duplicate characters in a string
    /// </summary>
    public class RemoveStringDuplicates : IAlgorithm
    {
        public void Run()
        {
            Console.WriteLine("Enter the string to remove duplicates from.");
            var givenString = Console.ReadLine();

            Console.WriteLine($"After removing the duplicates the string is {RemoveDuplicates(givenString)}.");
            Console.Write(Environment.NewLine);
        }

        private static string RemoveDuplicates(string givenString)
        {
            if (string.IsNullOrEmpty(givenString))
            {
                return string.Empty;
            }

            var characterDictionary = new Dictionary<char, int>();
            var duplicateRemovedString = new StringBuilder();


            for (int i = 0; i < givenString.Length; i++)
            {
                if (!characterDictionary.ContainsKey(givenString[i]))
                {
                    characterDictionary.Add(givenString[i], i);
                    duplicateRemovedString.Append(givenString[i]);
                }
            }
            return duplicateRemovedString.ToString();
        }
    }
}
