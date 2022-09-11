using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(@|#)(?<word>[A-Za-z]{3,})\1{2}(?<mirrorWord>[A-Za-z]{3,})\1";


            List<string> words = new List<string>();
            List<string> mirroredWords = new List<string>();

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> pairs = new List<string>();

            foreach (Match match in matches)
            {
                words.Add(match.Groups["word"].Value);
                mirroredWords.Add(match.Groups["mirrorWord"].Value);
            }

            for (int i = 0; i < mirroredWords.Count; i++)
            {
                string reversedWord = ReverseWord(mirroredWords[i]);

                if (words[i] == reversedWord)
                {
                    pairs.Add($"{words[i]} <=> {mirroredWords[i]}");
                }
                
            }
            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }
            if (pairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            if (pairs.Count > 0)
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", pairs));
                
            }

        }
        static string ReverseWord(string wordToReverse)
        {
            char[] charArray = wordToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
