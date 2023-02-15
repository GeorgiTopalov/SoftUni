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
            int[] lengths = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int n = lengths[0];
            int m = lengths[1];

            HashSet<int> setOfN = new HashSet<int>();

            HashSet<int> setOfM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                setOfN.Add(number);
            }

            for (int i = 0;i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                setOfM.Add(number);
            }

            List<int> duplicateNumbers = new List<int>();

            foreach (int num in setOfN)
            {
                if (setOfM.Contains(num))
                {
                    duplicateNumbers.Add(num);
                }
            }

            Console.WriteLine(String.Join(' ', duplicateNumbers));
        }
    }
}