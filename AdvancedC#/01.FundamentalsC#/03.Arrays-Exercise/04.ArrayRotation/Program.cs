using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int currentRotatingNumber = array[0];

                for (int j = 0; j < array.Length; j++)
                {
                    if (j == array.Length - 1)
                    {
                        array[j] = currentRotatingNumber;
                        break;
                    }
                    array[j] = array[j + 1];
                }
            }

            Console.WriteLine(String.Join(" ", array));

        }
    }
}