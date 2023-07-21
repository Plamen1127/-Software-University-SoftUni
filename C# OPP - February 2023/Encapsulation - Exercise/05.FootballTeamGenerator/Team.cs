using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team( string name)
        {
            this.Name = name;

            players = new List<Player>();
        }

        public int Reiting
            => this.players.Count > 0 ? (int)Math.Round(players.Average(p => p.OverallReiting)) : 0;

        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExsepshamMeseges.NameCannotBeNullOrEWhiteSpace));
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer( string playerName)
        {
            Player pleayerForRemove = this.players.FirstOrDefault(p => p.Name == playerName);

            if (pleayerForRemove == null)
            {
                throw new InvalidOperationException(string.Format( ExsepshamMeseges.MissingPlayerMessege, playerName, this.Name));
            }

            players.Remove(pleayerForRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Reiting}";
        }


    }
}
