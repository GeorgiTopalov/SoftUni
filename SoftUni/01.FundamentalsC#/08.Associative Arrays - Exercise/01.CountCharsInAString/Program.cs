using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            foreach (char ch in words)
            {
                if (ch != ' ')
                {
                    if (charOccurrences.ContainsKey(ch))
                    {
                        charOccurrences[ch]++;
                    }
                    else
                    {
                        charOccurrences.Add(ch, 1);
                    }
                }
            }

            foreach (var ch in charOccurrences)
            {
                Console.WriteLine($"{ch.Key} -> {ch.Value}");
            }
        }
    }
}
