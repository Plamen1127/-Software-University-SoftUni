using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public string ProducеSound();

        public void Eat(IFood food);
    }
}
