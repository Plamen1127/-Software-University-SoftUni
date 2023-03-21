




using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IIdentifiable, INamebale, IBirthable, IBuyer
    {
        private const int DefaultFoodIncrement = 10;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}
