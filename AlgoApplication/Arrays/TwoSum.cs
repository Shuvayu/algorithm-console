using AlgoIApplication;
using System;

namespace AlgoApplication.Arrays
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// Given nums = [2, 7, 11, 15], target = 9,
    /// Because nums[0] + nums[1] = 2 + 7 = 9,
    /// return [0, 1].
    /// </summary>
    public class TwoSum : IAlgorithm
    {

        private int ArraySize { get; set; }
        private int[] InputArray { get; set; }
        private int TargetValue { get; set; }

        public void Run()
        {
            Input();

            Process();

            Console.Write(Environment.NewLine);
        }

        private void Process()
        {
            var solutionFound = false;
            for (int i = 0; i < ArraySize - 1; i++)
            {
                for (int j = i + 1; j < ArraySize; j++)
                {
                    var sum = InputArray[i] + InputArray[j];
                    if (sum == TargetValue)
                    {
                        Console.WriteLine($"The indices of the two numbers are {i} and {j}");
                        solutionFound = true;
                        break;
                    }
                }
                if (solutionFound)
                {
                    break;
                }
            }
        }

        private void Input()
        {
            Console.WriteLine("Enter the total size of the array.");
            ArraySize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the integer array to be processed.");
            InputArray = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                InputArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the target number.");
            TargetValue = int.Parse(Console.ReadLine());
        }
    }
}
