using System;
using System.Linq;
using System.Collections.Generic;

namespace Fundamentals
{
    class Team
    {
        public Team(string teamName, string creator)
        {
            this.Name = teamName;
            this.TeamCreator = creator;

            this.TeamMembers = new List<string>();

        }

        public string Name { get; set; }
        public string TeamCreator { get; set; }
        public List<string> TeamMembers { get; set; }

        public void AddMember(string member)
        {
            this.TeamMembers.Add(member);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 1; i <= teamsCount; i++)
            {
                string[] action = Console.ReadLine().Split('-').ToArray();
                string user = action[0];
                string teamName = action[1];

                List<string> teamMembers = new List<string>();
                if (teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(team => team.TeamCreator == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(teamName, user);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }

            string addToTeam = String.Empty;

            while ((addToTeam = Console.ReadLine()) != "end of assignment")
            {
                string[] split = addToTeam.Split("->").ToArray();
                string member = split[0];
                string teamName = split[1];

                Team team = teams.FirstOrDefault(t => t.Name == teamName);

                if (team == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsAlreadyAMember(teams, member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }
                if (teams.Any(t=> t.TeamCreator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }

                team.AddMember(member);

            }

            List<Team> fullTeams = teams
                .Where(t => t.TeamMembers.Count > 0)
                .OrderByDescending(t => t.TeamMembers.Count)
                .ThenBy(t => t.Name)
                .ToList();
            List<Team> teamsToDisband = teams
                .Where(t => t.TeamMembers.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            foreach (Team fullTeam in fullTeams)
            {
                Console.WriteLine($"{fullTeam.Name}");
                Console.WriteLine($"- {fullTeam.TeamCreator}");

                foreach (string member in fullTeam.TeamMembers.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team emptyTeam in teamsToDisband)
            {
                Console.WriteLine($"{emptyTeam.Name}");
            }

        }
        static bool IsAlreadyAMember (List<Team> teams, string member)
        {
            foreach (Team team in teams)
            {
                if (team.TeamMembers.Contains(member))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
