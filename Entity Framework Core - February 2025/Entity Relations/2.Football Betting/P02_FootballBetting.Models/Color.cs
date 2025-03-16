using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Color
    {
        [Key]
        public int ColorId  { get; set; }

        [MaxLength(ValidationConstants.ColorNameMaxLegth)]
        public string Name { get; set; } = null!;
    }
}
