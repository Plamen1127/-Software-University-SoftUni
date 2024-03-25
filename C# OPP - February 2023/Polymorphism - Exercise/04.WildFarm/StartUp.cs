using System;
using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factory;
using WildFarm.Factory.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReadline();
            IWritre writre = new ConsoleWriter();
            IAnimalFactory animalFactory = new AnimalsFactory();
            IFoodFactory foodFactory = new FoodFactory();

            IEngine engine = new Engine(reader, writre, animalFactory, foodFactory);

            engine.Run();
        }
    }
}
