using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenIncreas = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override double WeightIncreas => HenIncreas;

        protected override IReadOnlyCollection<Type> PreferFood => new HashSet<Type>() { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override string ProducеSound()
        => "Cluck";
    }
}
