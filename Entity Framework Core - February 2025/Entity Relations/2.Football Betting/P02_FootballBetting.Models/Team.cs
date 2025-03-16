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
    public class Team
    {
        [Key]
        public int TeamId  { get; set; }

        [MaxLength(ValidationConstants.TeamNameMaxLegth)]
        public string Name { get; set; } = null!;


        [MaxLength(ValidationConstants.LogoUrlMaxLegth)]
        public string LogoUrl { get; set; } = null!;


        [MaxLength(ValidationConstants.InitialsMaxLegth)]
        public string Initials { get; set; } = null!;


        public decimal Budget { get; set; }


        [ForeignKey(nameof(PrimaryKitColorId))]
        public int PrimaryKitColorId { get; set; }
        public virtual Color PrimaryColor { get; set; } = null!;



        [ForeignKey(nameof(SecondaryKitColorId))]
        public int SecondaryKitColorId { get; set; }
        public virtual Color SecundaryColor { get; set; } = null!;
    }

}
