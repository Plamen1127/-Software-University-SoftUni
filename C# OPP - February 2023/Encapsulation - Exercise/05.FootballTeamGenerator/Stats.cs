using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExsepshamMeseges.InvalidStatMassege, nameof(this.Endurance)));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExsepshamMeseges.InvalidStatMassege, nameof(this.Sprint)));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExsepshamMeseges.InvalidStatMassege, nameof(this.Endurance)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }

            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentNullException(String.Format(ExsepshamMeseges.InvalidStatMassege, nameof(this.Sprint)));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(String.Format(ExsepshamMeseges.InvalidStatMassege, nameof(this.Shooting)));
                }

                shooting = value;
            }
        }

        public bool IsStatInvalid(int value)
       => value < 0 || value > 100;

    }
}
