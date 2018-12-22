using AlgoIApplication;
using System;
using System.Text;

namespace AlgoApplication.Strings
{
    /// <summary>
    /// Write a method to replace all spaces in a string with ‘%20’
    /// </summary>
    public class ReplaceSpacesInStrings : IAlgorithm
    {
        public void Run()
        {
            Console.WriteLine("Enter the string with spaces to replace.");
            var givenString = Console.ReadLine();

            Console.WriteLine($"The replaced string with builth in is : {ReplaceSpacesWithBuiltIn(givenString)}.");
            Console.WriteLine($"The replaced string with loop manupulation is : {ReplaceSpacesWithLoopManupulation(givenString)}.");
            Console.Write(Environment.NewLine);
        }

        private static string ReplaceSpacesWithBuiltIn(string givenString)
        {
            var replacesdString = givenString.Replace(" ", "%20");
            return replacesdString;
        }

        private static string ReplaceSpacesWithLoopManupulation(string givenString)
        {
            var replacesdString = new StringBuilder();

            foreach (var character in givenString)
            {
                if (character == ' ')
                {
                    replacesdString.Append("%20");
                }
                else
                {
                    replacesdString.Append(character);
                }
            }
            return replacesdString.ToString();
        }
    }
}
