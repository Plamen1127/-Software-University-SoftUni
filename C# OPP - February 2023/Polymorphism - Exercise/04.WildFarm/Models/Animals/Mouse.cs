﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseIncreas = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncreas =>MouseIncreas;

        protected override IReadOnlyCollection<Type> PreferFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit)};

        public override string ProducеSound()
       => "Squeak";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
