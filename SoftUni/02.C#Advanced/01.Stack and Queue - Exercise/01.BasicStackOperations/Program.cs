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
            int elementsToPop = requirements[1];
            int numberToLookFor = requirements[2];

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> savedNumbers = new Stack<int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                savedNumbers.Push(numbers[i]);
            }
            for (int i = 0;i < elementsToPop; i++)
            {
                savedNumbers.Pop();
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
                        smallestNumber = savedNumbers.Pop();
                    }
                    else
                    {
                        savedNumbers.Pop();
                    }
                }
                Console.WriteLine(smallestNumber);
                return;
            }
            Console.WriteLine("0");

        }
    }
}

