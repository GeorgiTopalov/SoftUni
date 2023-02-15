using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            NumsToSwap<int> numbersToSwap = new NumsToSwap<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbersToSwap.Numbers.Add(number);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            numbersToSwap.Swap(indexes[0], indexes[1]);

            Console.WriteLine(numbersToSwap);

        }
    }
}
