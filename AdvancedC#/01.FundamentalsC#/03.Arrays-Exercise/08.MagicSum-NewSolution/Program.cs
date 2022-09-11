using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] magicNumbers = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < magicNumbers.Length - 1; i++)
            {
                int currentSum = 0;

                for (int j = i+1; j < magicNumbers.Length; j++)
                {
                    currentSum = magicNumbers[i] + magicNumbers[j];
                    if (currentSum == magicSum)
                    {
                        Console.WriteLine($"{magicNumbers[i]} {magicNumbers[j]}");
                    }
                }
            }

        }
    }
}