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
            string title = "Sir ";

            Action<string[]> knighthood = names => Console.WriteLine(title + string.Join(Environment.NewLine + title, names));

            knighthood(names);
        }
    }
}