using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advanced
{
    class Vlogger
    {
        public Vlogger(HashSet<string> following, HashSet<string> followers)
        {
            this.Following = following;
            this.Followers = followers;
        }
        public string Name { get; set; }

        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, Vlogger> vloggers =
                new Dictionary<string, Vlogger>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vloggerName = inputArgs[0];
                string action = inputArgs[1];

                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        Vlogger newVlogger = new Vlogger(new HashSet<string>(), new HashSet<string>());
                        newVlogger.Name = vloggerName;
                        vloggers.Add(vloggerName, newVlogger);
                    }
                }
                else
                {
                    string vloggerToFollow = inputArgs[2];
                    if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(vloggerToFollow))
                    {
                        if (vloggerToFollow != vloggerName)
                        {
                            vloggers[vloggerToFollow].Followers.Add(vloggerName);
                            vloggers[vloggerName].Following.Add(vloggerToFollow);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            Vlogger mostFamousVlogger = ReturnMostFamousVlogger(vloggers);

            Console.WriteLine($"1. {mostFamousVlogger.Name} : {mostFamousVlogger.Followers.Count} followers, {mostFamousVlogger.Following.Count} following");

            foreach (var follower in mostFamousVlogger.Followers.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            vloggers.Remove(mostFamousVlogger.Name);

            int counter = 2;

            foreach (var vlogger in vloggers.Values.OrderByDescending(x => x.Followers.Count).ThenBy(y => y.Following.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                counter++;
            }
        }
        static Vlogger ReturnMostFamousVlogger(Dictionary<string, Vlogger> vloggers)
        {
            int mostFollowers = 0;
            int leastFollowing = 0;

            Vlogger mostFamousVlogger = null;

            foreach (var vlogger in vloggers.Values)
            {
                if (vlogger.Followers.Count == mostFollowers)
                {
                    if (vlogger.Following.Count < leastFollowing)
                    {
                        mostFollowers = vlogger.Following.Count;
                        mostFamousVlogger = vlogger;
                    }
                }
                if (vlogger.Followers.Count > mostFollowers)
                {
                    mostFollowers = vlogger.Followers.Count;
                    leastFollowing = vlogger.Following.Count;
                    mostFamousVlogger = vlogger;
                }
            }
            return mostFamousVlogger;
        }

    }
}