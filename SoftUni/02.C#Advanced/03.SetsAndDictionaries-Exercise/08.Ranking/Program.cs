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
            Dictionary<string, string> contests = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string,int>> users = new Dictionary<string, Dictionary<string, int>>();

            string newContest = string.Empty;

            while ((newContest = Console.ReadLine()) != "end of contests")
            {
                string[] newContestArgs = newContest
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = newContestArgs[0];
                string password = newContestArgs[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            string submissions = string.Empty;

            while ((submissions = Console.ReadLine())!= "end of submissions")
            {
                string[] submissionsArgs = submissions
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = submissionsArgs[0];
                string password = submissionsArgs[1];
                string username = submissionsArgs[2];
                int points = int.Parse(submissionsArgs[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int> ());
                        users[username].Add(contest, points);
                    }
                    else if (users[username].ContainsKey(contest))
                    {
                        if (users[username][contest] < points)
                        {
                            users[username][contest] = points;
                        }
                    }
                    else
                    {
                        users[username].Add(contest, points);
                    }
                }
            }

            string bestCandidate = string.Empty;
            int mostPoints = 0;

            foreach (var user in users)
            {
                int totalPoints = 0;

                foreach (var contest in user.Value)
                {
                    totalPoints += contest.Value;
                }
                if (totalPoints > mostPoints)
                {
                    mostPoints = totalPoints;
                    bestCandidate = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {mostPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}