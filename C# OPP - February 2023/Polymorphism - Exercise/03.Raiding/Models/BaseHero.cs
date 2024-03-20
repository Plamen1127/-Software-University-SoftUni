using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, double power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }

        public double Power { get; private set; }

        public abstract string CastAbility();
        
    }
}
