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
            List<string> participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            Dictionary<string, int> participantsDistance = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "end of race")
            {
                string participantName = string.Empty;
                int currentDistance = 0;

                MatchCollection name = Regex.Matches(command, @"[A-Za-z]");

                foreach (Match match in name)
                {
                    participantName += match.Value;
                }

                MatchCollection distance = Regex.Matches(command, @"[0-9]");

                foreach (Match match in distance)
                {
                    currentDistance += int.Parse(match.Value);
                }

                if (participants.Contains(participantName))
                {
                    if (!participantsDistance.ContainsKey(participantName))
                    {
                        participantsDistance.Add(participantName, currentDistance);
                    }
                    else
                    {
                        participantsDistance[participantName] += currentDistance;
                    }
                }

            }

            var winners = participantsDistance.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var name in firstPlace)
            {
                Console.WriteLine($"1st place: {name.Key}");

            }
            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");

            }
            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");

            }
        }
    }
}
