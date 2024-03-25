using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlIncreas = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightIncreas => OwlIncreas;

        protected override IReadOnlyCollection<Type> PreferFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProducеSound()
        => "Hoot Hoot";

    }
}
