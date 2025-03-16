﻿using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Position
    {
        [Key]
        public int PositionId  { get; set; }

        [MaxLength(ValidationConstants.PositionNameMaxLegth)]
        public string Name { get; set; } = null!;

    }
}
