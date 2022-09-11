using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeOfNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = rangeOfNumbers[0]; i <= rangeOfNumbers[1]; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> oddEven = x => x % 2 != 0;

            List<int> finalOutput = new List<int>();

            if (command == "even")
            {
                 finalOutput = numbers.FindAll(isEven);
            }
            else
            {
                finalOutput = numbers.FindAll(oddEven);
            }

            Console.WriteLine(String.Join(" ", finalOutput));

        }
    }
}