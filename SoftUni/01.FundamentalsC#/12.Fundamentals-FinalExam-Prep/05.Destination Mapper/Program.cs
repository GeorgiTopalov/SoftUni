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
            string allDestination = Console.ReadLine();

            string pattern = @"(=|\/)(?<place>[A-Z][A-Za-z]{2,})\1";

            List<string> destinations = new List<string>();

            MatchCollection matches = Regex.Matches(allDestination, pattern);

            int travelPoints = 0;

            Console.Write($"Destinations: ");

            foreach (Match match in matches)
            {
                destinations.Add(match.Groups["place"].Value);
                travelPoints += match.Groups["place"].Value.Length;
            }

            Console.Write(string.Join(", ", destinations.ToArray()));

            Console.WriteLine();
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
