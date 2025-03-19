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
    public class Town
    {
        public Town()
        {
                Players = new List<Player>();   
        }

        [Key]
        public int TownId { get; set; }
        

        [MaxLength(ValidationConstants.TownNameMaxLegth)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Player> Players { get; set; }


    }
} 
