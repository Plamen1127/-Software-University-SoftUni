using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Exceptions;
using WildFarm.Factory.Interfaces;
using WildFarm.Models.Food;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Factory
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string typeFood, int qty)
        {
            IFood food;
            if (typeFood == "Vegetable")
            {
                food = new Vegetable(qty);
            }
            else if (typeFood == "Fruit")
            {
                food = new Fruit(qty);
            }
            else if ( typeFood == "Meat")
            {
                food = new Meat(qty);
            }
            else if (typeFood == "Seeds")
            {
                food = new Seeds(qty);
            }
            else
            {
                throw new InvalidTypeFoodException(string.Format(ExceptionsMessages.InvalidTypefood));
            }
            
            return food;
        } 
    }
}
