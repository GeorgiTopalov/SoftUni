using System;
using System.Linq;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool isBigger = true;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[i] > array[j + 1])
                    {
                        isBigger = true;
                    }
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }
                if ((isBigger == true) || (i == array.Length - 1))
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}