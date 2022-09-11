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
            string text = Console.ReadLine();

            SortedDictionary<char, int> charactersCount = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!charactersCount.ContainsKey(text[i]))
                {
                    charactersCount.Add(text[i], 0);
                }
                charactersCount[text[i]]++;
            }

            foreach(var character in charactersCount)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}