using System;
using System.Linq;

namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> func = (x, y) =>
            {
                return (x % 2 == 0 && y % 2 != 0)
                 ? -1
                 : (x % 2 != 0 && y % 2 == 0)
                 ? 1
                 : x > y
                 ? 1
                 : x < y
                 ? -1
                 : 0;
            };

            Array.Sort(array, (x, y) => func(x, y));

            Console.WriteLine(String.Join(" ", array));
        }
    }
}
