using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double StartRating = 5.5;
        private const double RatingIncrease = 1.25;
        private const double RatingDecrease = 0.75;
        public ForwardWing(string name)
            : base(name, StartRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= RatingDecrease;
        }

        public override void IncreaseRating()
        {
           Rating+= RatingIncrease;
        }
    }
}
