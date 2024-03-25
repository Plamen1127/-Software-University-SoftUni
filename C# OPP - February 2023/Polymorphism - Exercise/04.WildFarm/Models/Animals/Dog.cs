﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogIncreas = 0.4;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncreas => DogIncreas;

        protected override IReadOnlyCollection<Type> PreferFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProducеSound()
       => "Woof!";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
