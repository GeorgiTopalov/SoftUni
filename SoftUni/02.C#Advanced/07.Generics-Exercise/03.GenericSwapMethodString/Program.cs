using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            WordsToSwap<string> stringsToSwap = new WordsToSwap<string>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();   

                stringsToSwap.Words.Add(word);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            stringsToSwap.Swap(indexes[0], indexes[1]);

            Console.WriteLine(stringsToSwap);

        }
    }
}
