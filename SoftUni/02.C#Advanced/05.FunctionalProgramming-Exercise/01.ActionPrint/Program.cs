using System;
using System.Collections.Generic;

namespace Raffle
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Print(names, x => Console.WriteLine(x)); 

        }

        private static void Print (string[] names,Action<string> callback)
        {
            foreach(var name in names)
            {
                callback(name);
            }
        }
    }
}