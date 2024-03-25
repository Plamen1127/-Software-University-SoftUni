using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Exceptions;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
           
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightIncreas { get; }

        protected abstract IReadOnlyCollection<Type> PreferFood { get; }

        public void Eat(IFood food)
        {
            if (!PreferFood.Any(pf=>pf.Name == food.GetType().Name))
            {
                throw new AnimalDoesNotEeatThisFoodException(string.Format(ExceptionsMessages.AnimalDoesNotEatFoodType, this.GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * WeightIncreas;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProducеSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";   
        }
    }
}
