using P02_FootballBetting.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Bet
    {
        [Key]
        public int BetId  { get; set; }

        public decimal Amount { get; set; }

        public Prediction Prediction { get; set; }
    }
}
