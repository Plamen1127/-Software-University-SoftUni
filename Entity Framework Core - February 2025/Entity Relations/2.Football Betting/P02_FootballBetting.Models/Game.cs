using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Game
    {
        public Game()
        {
            Games = new List<Game>();
            PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int GameId { get; set; }


        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; } = null!;


        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; } = null!;

        public byte MyPrHomeTeamGoals { get; set; }
        public byte AwayTeamGoals { get; set; }
        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }

        public DataType DateTime { get; set; }

        [MaxLength(ValidationConstants.ResultMaxLegth)]
        public string Result { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
