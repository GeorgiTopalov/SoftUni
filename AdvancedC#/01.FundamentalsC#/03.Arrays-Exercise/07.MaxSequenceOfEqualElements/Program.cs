using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int firstCounter = 1;
            int secondCounter = 0;
            int currentNumber = 0;

            for (int i = 0; i  < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    firstCounter++;

                }
                if (firstCounter > secondCounter)
                {
                    secondCounter = firstCounter;
                    currentNumber = array[i];
                }
                

                else if (array[i] != array[i + 1])
                {
                    firstCounter = 1;
                }
            }

            int[] outputArray = new int[secondCounter];
            Array.Fill(outputArray, currentNumber);

            Console.WriteLine(String.Join(" ", outputArray));
        }
    }
}