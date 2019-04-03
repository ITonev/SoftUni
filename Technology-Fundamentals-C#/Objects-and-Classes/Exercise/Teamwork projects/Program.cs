using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_projects
{
    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            int teamCounts = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCounts; i++)
            {
                var input = Console.ReadLine().Split("-");
                var creator = input[0];
                var teamName = input[1];

                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }

                else if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                else
                {
                    Team currentTeam = new Team();
                    currentTeam.Creator = creator;
                    currentTeam.TeamName = teamName;
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of assignment")
                {
                    break;
                }

                var tokens = command.Split("->");

                var user = tokens[0];
                var team = tokens[1];

                if (!teams.Any(x=>x.TeamName==team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Any(x=>x.Creator==user) || (teams.Any(x=>x.Members.Contains(user))))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }

                else
                {
                    int teamIndex = teams.FindIndex(x => x.TeamName == team);
                    teams[teamIndex].Members.Add(user);
                }
            }

            var teamsWithoutMembers = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            var teamsWithMembers = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine($"{team.TeamName}\n- {team.Creator}");
                Console.WriteLine("-- "+string.Join("\n-- ", team.Members.OrderBy(x=>x)));

            }

            Console.WriteLine("Teams to disband:");
            if (teamsWithoutMembers.Count>0)
            {
                foreach (var team in teamsWithoutMembers)
                {
                    Console.WriteLine(team.TeamName);
                }
            }
                
        }
    }
}
