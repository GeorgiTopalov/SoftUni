using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            string allEmojis = Console.ReadLine();

            string pattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string tresholdPattern = @"[0-9]";
            BigInteger coolTreshold = new BigInteger(1);

            MatchCollection digitMatches = Regex.Matches(allEmojis, tresholdPattern);

            foreach (Match digit in digitMatches)
            {
                coolTreshold *= int.Parse(digit.Value);
            }

            MatchCollection matches = Regex.Matches(allEmojis, pattern);
            List<string> validEmojis = new List<string>();
            List<string> coolEmojis = new List<string>();


            foreach (Match match in matches)
            {
                validEmojis.Add(match.Value);
            }

            for (int i = 0; i < validEmojis.Count; i++)
            {
                int currentEmojiSum = 0;

                char[] currEmoji = validEmojis[i].ToCharArray();
                for (int j = 0; j < currEmoji.Length; j++)
                {
                    if (currEmoji[j] != ':' && currEmoji[j] != '*')
                    currentEmojiSum += currEmoji[j];
                }

                if (currentEmojiSum >= coolTreshold)
                {
                    coolEmojis.Add(validEmojis[i]);
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");

            Console.WriteLine($"{validEmojis.Count} emojis found in the text. The cool ones are:");

            foreach (var emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
