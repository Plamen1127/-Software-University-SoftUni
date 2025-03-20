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
    public class Color
    {

        public Color()
        {
            PrimaryKitTeams = new List<Team>();
            SecondaryKitTeams = new List<Team>();
        }

        [Key]
        public int ColorId { get; set; }

        [MaxLength(ValidationConstants.ColorNameMaxLegth)]
        public string Name { get; set; } = null!;


        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }


        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
