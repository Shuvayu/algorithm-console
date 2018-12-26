using AlgoIApplication;
using System;

namespace AlgoApplication.Arrays
{
    /// <summary>
    /// Say you have an array for which the ith element is the price of a given stock on day i.
    /// If you were only permitted to complete at most one transaction(i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
    /// Note that you cannot sell a stock before you buy one.
    /// Example 1:
    ///   Input: [7,1,5,3,6,4]
    /// Output: 5
    ///     Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    ///              Not 7-1 = 6, as selling price needs to be larger than buying price.
    /// Example 2:
    /// Input: [7,6,4,3,1]
    ///     Output: 0
    /// Explanation: In this case, no transaction is done, i.e.max profit = 0.
    /// </summary>
    public class BuyOneSellOne : IAlgorithm
    {
        private int ArraySize { get; set; }
        private int[] InputArray { get; set; }

        public void Run()
        {
            Input();
            Process();
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
        }

        private void Process()
        {
            var maxProfit = 0;
            var buyIndex = 0;
            var sellIndex = 0;
            for (int i = 0; i < ArraySize - 1; i++)
            {
                for (int j = i + 1; j < ArraySize; j++)
                {
                    var totalProfit = InputArray[j] - InputArray[i];
                    if (maxProfit < totalProfit)
                    {
                        maxProfit = totalProfit;
                        buyIndex = i;
                        sellIndex = j;
                    }
                }
            }
            Output(buyIndex, sellIndex);
        }

        private void Output(int buyIndex, int sellIndex)
        {
            if (sellIndex == 0)
            {
                Console.WriteLine("There is no best day to do a transaction to gain a profit.");
            }
            else
            {
                Console.WriteLine($"The Buy on day {buyIndex} (price = {InputArray[buyIndex]}) and sell on day {sellIndex} (price = {InputArray[sellIndex]}), profit = {InputArray[sellIndex]}-{InputArray[buyIndex]} = {InputArray[sellIndex] - InputArray[buyIndex]}.");
            }
        }
    }
}
