using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;

        private string[] validTypePlayers = new string[] { typeof(CenterBack).Name, typeof(ForwardWing).Name, typeof(Goalkeeper).Name };



        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            ITeam team = new Team(name);

            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, typeof(TeamRepository).Name);
            }

            teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, typeof(TeamRepository).Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!validTypePlayers.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
           
            if (players.ExistsModel(name))
            {
                IPlayer currentPlayer= players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, typeof(PlayerRepository).Name, currentPlayer.GetType().Name);
            }

            IPlayer player = null;
            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else
            {
                player = new ForwardWing(name);
            }

            players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, typeof(PlayerRepository).Name);
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
            }

            IPlayer player = players.GetModel(playerName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);

            ITeam team = teams.GetModel(teamName);

            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            ITeam winTeam = null;
            ITeam lostTeam = null;
            bool isDraw = false;

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winTeam = firstTeam;
                lostTeam = secondTeam;
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                winTeam = secondTeam;
                lostTeam = firstTeam;
            }
            else
            {
                isDraw = true;
            }

            if (isDraw)
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
            else
            {
                winTeam.Win();
                lostTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, winTeam.Name, lostTeam.Name);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            ITeam team = teams.GetModel(teamName);

            List<IPlayer> playersArranged = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            

            foreach (IPlayer player in playersArranged)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd(); ;

        }

        public string LeagueStandings()
        {
            List<ITeam> teamsArranged = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***League Standings***");

            foreach (var team in teamsArranged)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }









    }
}
