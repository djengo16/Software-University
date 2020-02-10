using System;
using System.Collections.Generic;
using System.Linq;
namespace TeamworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] currentTeam = Console.ReadLine().Split("-").ToArray();
                string teamCreatorName = currentTeam[0];
                string teamName = currentTeam[1];
                if (CheckIfExist(teamName, teams) && CheckCreator(teamCreatorName, teams))
                {
                    Team team = new Team();
                    team.Creator = teamCreatorName;
                    team.TeamName = teamName;
                    Console.WriteLine($"Team {teamName} has been created by {teamCreatorName}!");
                    teams.Add(team);
                }
                else
                {
                    if (!CheckIfExist(teamName, teams))
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                    if (!CheckCreator(teamCreatorName, teams))
                    {
                        Console.WriteLine($"{teamCreatorName} cannot create another team!");
                    }
                }
            }
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
               string[] command1 = command.Split("->").ToArray();
                string member = command1[0];
                string team = command1[1];
                if ((!CheckIfExist(team, teams)) && checkIfItsAlreadyInteam(member,teams))
                {
                    for (int i = 0; i < teams.Count; i++)
                    {
                        if (teams[i].TeamName == team)
                        {
                            teams[i].Members.Add(member);
                        }
                    }
                }
                if (!CheckIfExist(team,teams))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                if (!checkIfItsAlreadyInteam(member,teams))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }

            }
            teams = teams.OrderBy(x => x.TeamName).ToList();

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count != 0)
                {
                    Console.WriteLine(teams[i].TeamName);
                    Console.WriteLine($"-{teams[i].Creator}");
                    Console.WriteLine(String.Join(Environment.NewLine+"--",teams[i].Members));
                }
                
            }
            for (int i = 0; i < teams.Count ; i++)
            {
                Console.WriteLine("Teams to disband:");
                if (teams[i].Members.Count == 0)
                {
                    Console.WriteLine(teams[i].TeamName);
                }
            }
        }
        public static bool checkIfItsAlreadyInteam(string member,List<Team> teams)
        {
   
                //if (teams.Any(x => x.Users.Contains(user)) || teams.Any(x => x.Creator == user))
                if (teams.Any(x=>x.Members.Contains(member)))
                {                   
                    return false;
                }
            
            return true;
        }
        public static bool CheckIfExist(string currentTeamName, List<Team> teams)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].TeamName == currentTeamName)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckCreator(string currentCreator, List<Team> teams)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Creator == currentCreator)
                {
                    return false;
                }
            }
            return true;
        }
    }
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        
    }
}
