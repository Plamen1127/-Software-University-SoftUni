using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const double DefoltPawer = 80;

        public Druid(string name)
            : base(name, DefoltPawer)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
