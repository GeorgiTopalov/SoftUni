using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArrays = int.Parse(Console.ReadLine());

            int[] firstOutput = new int[numberOfArrays];
            int[] secondOutput = new int[numberOfArrays];
            for (int i = 0; i < numberOfArrays; i++)
            {
                int[] currentArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstOutput[i] = currentArray[0];
                    secondOutput[i] = currentArray[1];
                }
                else
                {
                    firstOutput[i] = currentArray[1];
                    secondOutput[i] = currentArray[0];
                }
            }

            Console.WriteLine(String.Join(" ", firstOutput));
            Console.WriteLine(String.Join(" ", secondOutput));
        }
    }
}