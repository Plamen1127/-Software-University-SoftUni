using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatIncreas = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightIncreas => CatIncreas;

        protected override IReadOnlyCollection<Type> PreferFood => new HashSet<Type>() { typeof(Vegetable), typeof(Meat)};

        public override string ProducеSound()
       => "Meow";
    }
}
