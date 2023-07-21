using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teams;


        static void Main(string[] args)
        {
            teams = new List<Team>();

            string command;

            
            while ((command=Console.ReadLine()) != "END")
            {
                string[] cmdArgums = command.Split(";");

                string cmdType = cmdArgums[0];
                string teamName = cmdArgums[1];

                try
                {
                    if (cmdType == "Team")
                    {
                        AddNewTeam(teamName);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(teamName, cmdArgums);
                    }
                    else if (cmdType == "Remove")
                    {
                        string playerName = cmdArgums[2];
                        RemovePlayerFroTeam(teamName, playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        Ratingteam(teamName);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
               
            }
        }

        static void AddNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teams.Add(newTeam);
        }

        static void AddPlayerToTeam(string teamName, string[] cmdArgums)
        {
            Team joiningTeam = teams.FirstOrDefault(t => t.Name == teamName);
            if (joiningTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExsepshamMeseges.MissingTeamMessege, teamName));
            }

            string playerName = cmdArgums[2];
            int endurance = int.Parse(cmdArgums[3]);
            int sprint = int.Parse(cmdArgums[4]);
            int dribble = int.Parse(cmdArgums[5]);
            int passing = int.Parse(cmdArgums[6]);
            int shooting = int.Parse(cmdArgums[7]);

            Player joiningPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            joiningTeam.AddPlayer(joiningPlayer);
        }

        static void RemovePlayerFroTeam(string nameTeam, string playerName)
        {
            Team removeFromTeam = teams.FirstOrDefault(t => t.Name == nameTeam);
            if (removeFromTeam==null)
            {
                throw new InvalidOperationException(string.Format(ExsepshamMeseges.MissingTeamMessege, nameTeam));
            }

            removeFromTeam.RemovePlayer(playerName);
        }

        static void Ratingteam(string teamName)
        {
            Team ratingTeam = teams.FirstOrDefault(t => t.Name == teamName);
            if (ratingTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExsepshamMeseges.MissingTeamMessege, teamName));
            }
            Console.WriteLine(ratingTeam);
        }
    }
}
