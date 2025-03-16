using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class Player
    {
        public int PlayerId  { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }


    }
}
