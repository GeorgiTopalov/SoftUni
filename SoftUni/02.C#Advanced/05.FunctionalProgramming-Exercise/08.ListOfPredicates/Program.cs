using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            List<int> divisibleNums = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                int count = 0;

                for (int j = 0; j < sequence.Count; j++)
                {
                    Predicate<int> isDivisable = x => x % sequence[j] == 0;

                    if (isDivisable(i))
                    {
                        count++;
                    }
                }
                if (count == sequence.Count)
                {
                    divisibleNums.Add(i);
                }
            }

            Action<List<int>> print = x => Console.WriteLine(string.Join(' ', x));

            print(divisibleNums);
        }
    }
}