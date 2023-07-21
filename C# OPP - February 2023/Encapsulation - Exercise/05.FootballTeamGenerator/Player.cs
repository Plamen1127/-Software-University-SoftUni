using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;

            this.Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name 
        {
            get
            {
                return name;
            } 
             private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExsepshamMeseges.NameCannotBeNullOrEWhiteSpace, nameof(this.Name)));
                }

                name = value;
            }
        }

        public Stats Stats { get; private set; }

        public double OverallReiting
            => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.0;
    }
}
