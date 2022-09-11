using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> specialNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            for (int i = 0; i < specialNumbers.Count; i++)
            {
                if (specialNumbers[i] == bomb)
                {
                    int explosionStart = i - power;
                    int explosionEnd = power * 2 + 1;

                    if (power > i)
                    {
                        explosionStart = 0;
                    }
                    if (explosionEnd > specialNumbers.Count - i)
                    {
                        explosionEnd = specialNumbers.Count - (specialNumbers.Count - i);
                    }
                    if (explosionStart >= explosionEnd)
                    {
                        explosionEnd = power+1;
                    }

                    specialNumbers.RemoveRange(explosionStart, explosionEnd);
                    i = -1;
                }
            }
            int sum = specialNumbers.Sum(x => x);
            if (specialNumbers.Count == 0)
            {
                sum = 0;
            }
            Console.WriteLine(sum);
        }
    }
}
