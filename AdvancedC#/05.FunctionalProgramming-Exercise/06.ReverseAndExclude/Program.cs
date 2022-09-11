using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisibleByN = number => number % n == 0;
            numbers.Reverse();
            numbers = numbers.Where(x => isDivisibleByN(x) == false).ToList();

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}