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

            string input = string.Empty;
            Dictionary<string, int> contests = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string,int>>();

            while((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = inputArgs[0];

                if (inputArgs[1] != "banned")
                {
                    string language = inputArgs[1];
                    int points = int.Parse(inputArgs[2]);

                    if (!contests.ContainsKey(language))
                    {
                        contests.Add(language, 0);
                    }
                    if (!results.ContainsKey(username))
                    {
                        results.Add(username, new Dictionary<string, int>());
                        results[username].Add(language, points);
                    }
                    else
                    {
                        if (results[username].ContainsKey(language))
                        {
                            if (results[username][language] < points)
                            {
                                results[username][language] = points;
                            }
                        }
                        else 
                        {
                            results[username].Add(language, points);
                        }
                        if (!contests.ContainsKey(language))
                        {
                            contests.Add(language, 0);
                        }
                    }
                    contests[language]++;
                }
                else
                {
                    if (results.ContainsKey(username))
                    {
                        results.Remove(username);
                    }
                }
            }

            Console.WriteLine("Results:");

            Dictionary<string, int> orderedResults = GetOrderedResults(results);

            foreach (var contestant in orderedResults.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{contestant.Key} | {contestant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var contest in contests.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{contest.Key} - {contest.Value}");
            }

        }
        static Dictionary<string, int> GetOrderedResults(Dictionary<string, Dictionary<string, int>> results)
        {
            Dictionary<string, int> orderedResults = new Dictionary<string, int>();

            foreach (var contestant in results)
            {
                int bestScore = 0;

                foreach (var contest in contestant.Value)
                {
                    if (contest.Value > bestScore)
                    {
                        bestScore = contest.Value;
                    }
                }
                orderedResults.Add(contestant.Key, bestScore);
            }
            return orderedResults;
        }
    }
}