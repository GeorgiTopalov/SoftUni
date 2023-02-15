using System;
using System.Collections.Generic;
using System.Linq;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int, bool> isShorter = (name, length) => name.Length <= length;

            string[] shortNames = names.Where(x => isShorter(x, length)).ToArray();

           

            
                Console.WriteLine(String.Join(Environment.NewLine, shortNames));
            
        }
    }
}