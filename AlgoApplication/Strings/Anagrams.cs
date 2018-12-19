using AlgoIApplication;
using System;
using System.Text;

namespace AlgoApplication.Strings
{
    public class Anagrams : IAlgorithm
    {
        public void Run()
        {
            Console.WriteLine("Enter the string to for an anagram.");
            var givenString = Console.ReadLine();

            if (CheckAnagram(givenString))
            {
                Console.WriteLine($"The string is an Anagram.");
            }
            else
            {
                Console.WriteLine($"The string is not an Anagram.");
            }
            Console.Write(Environment.NewLine);
        }

        private static bool CheckAnagram(string givenString)
        {
            var reversedString = new StringBuilder();

            for (int j = givenString.Length - 1; j >= 0; j--)
            {
                reversedString.Append(givenString[j]);
            }

            return Equals(givenString, reversedString.ToString()) ? true : false;
        }
    }
}
