using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Exceptions
{
    public static class ExceptionsMessages
    {
        public const string AnimalDoesNotEatFoodType = "{0} does not eat {1}!";
        public const string InvalidAnimalType = "Invalid animal type";
        public const string InvalidTypefood = "Invalid food type";
    }
}
