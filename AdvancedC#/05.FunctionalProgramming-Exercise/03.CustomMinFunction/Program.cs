using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNum = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (int number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            int numToPrint = smallestNum(numbers);

            Console.WriteLine(numToPrint);
            
        }
    }
}