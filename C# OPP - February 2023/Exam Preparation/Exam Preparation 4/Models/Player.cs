using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        protected Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating
        {
            get
            {
                return rating;
            }
            protected set
            {
                if (value > 10)
                {
                    rating = 10;
                    return;
                }
                else if (value < 1)
                {
                    rating = 1;
                    return;
                }

                rating = value;

            }
        }

        public string Team
        {
            get
            {
                return team;
            }
        }

        public abstract void DecreaseRating();


        public abstract void IncreaseRating();


        public void JoinTeam(string name)
        => team = name;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
