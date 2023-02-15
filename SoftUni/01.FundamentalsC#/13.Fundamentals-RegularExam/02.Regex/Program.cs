using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RegexProplem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]";
            Regex regex = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]");

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                MatchCollection matches = regex.Matches(text);

                if (matches.Count == 0)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    foreach (Match match in matches)
                    {
                        Console.Write($"{match.Groups["command"]}: ");
                        string message = match.Groups["string"].ToString();
                        foreach (char ch in message)
                        {
                            int asciiCode = ch;
                            Console.Write($"{asciiCode} ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
