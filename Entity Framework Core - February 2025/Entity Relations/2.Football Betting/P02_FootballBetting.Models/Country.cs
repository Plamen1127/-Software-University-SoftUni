﻿using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Country
    {
        public Country()
        {
                Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [MaxLength(ValidationConstants.CountryNameMaxLegth)]
        public string Name { get; set; } = null!;

        public ICollection<Town> Towns { get; set; }
    }
}
