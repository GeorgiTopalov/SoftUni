using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] requirements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberOfElements = requirements[0];
            int elementsToEnqueue = requirements[1];
            int numberToLookFor = requirements[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> savedNumbers = new Queue<int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                savedNumbers.Enqueue(numbers[i]);
            }
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                savedNumbers.Dequeue();
            }
            if (savedNumbers.Count > 0)
            {
                foreach (int num in savedNumbers)
                {
                    if (num == numberToLookFor)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                }
                int smallestNumber = int.MaxValue;
                while (savedNumbers.Count > 0)
                {
                    if (smallestNumber > savedNumbers.Peek())
                    {
                        smallestNumber = savedNumbers.Dequeue();
                    }
                    else
                    {
                        savedNumbers.Dequeue();
                    }
                }
                Console.WriteLine(smallestNumber);
                return;
            }
            Console.WriteLine("0");

        }
    }
}

