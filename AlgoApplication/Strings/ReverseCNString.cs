using AlgoIApplication;
using System;
using System.Text;

namespace AlgoApplication.Strings
{
    /// <summary>
    /// Write code to reverse a C-Style and Normal String
    /// (C-String means that “abcd” is represented as five characters, including the null character )
    /// </summary>
    public class ReverseCNString : IAlgorithm
    {
        public void Run()
        {
            Console.WriteLine("Enter the string to reverse.");
            var givenString = Console.ReadLine();

            Console.WriteLine($"The reverse of the provided string {givenString} is {ReverseNormalWithStringBuilder(givenString)}.");
            Console.Write(Environment.NewLine);
        }

        private static string ReverseNormalWithStringBuilder(string givenString)
        {
            var reversedString = new StringBuilder();

            for (int i = givenString.Length - 1; i >= 0; i--)
            {
                reversedString.Append(givenString[i]);
            }
            return reversedString.ToString();
        }
    }
}
