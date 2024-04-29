using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double StartRating = 4;
        private const double RatingIncrease = 1;
        private const double RatingDecrease = 1;
        public CenterBack(string name) 
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
