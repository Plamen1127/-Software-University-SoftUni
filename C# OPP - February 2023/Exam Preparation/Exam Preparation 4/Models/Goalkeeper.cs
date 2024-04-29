using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double StartRating = 2.5;
        private const double RatingIncrease = 0.75;
        private const double RatingDecrease = 1.25;
        public Goalkeeper(string name)
            : base(name, StartRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= RatingDecrease;
        }

        public override void IncreaseRating()
        {
            Rating += RatingIncrease;
        }
    }
}
