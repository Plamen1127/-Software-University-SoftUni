using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Exceptions;
using WildFarm.Factory;
using WildFarm.Factory.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWritre writre;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

       private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWritre writre, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writre = writre;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            animals = new HashSet<IAnimal>();
           
        }
        
        public void Run()
        {
            
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = BildAnimalUsingAnimalFactory(command);
                    IFood food = BildFoodUsingFoodFactory();

                     this.writre.WriteLine(animal.ProducеSound());

                    animal.Eat(food);
                }
                catch (AnimalDoesNotEeatThisFoodException adnetfe)
                {
                    this.writre.WriteLine(adnetfe.Message);
                }
                catch (InvalidAnimalTypeException itae)
                {
                    this.writre.WriteLine(itae.Message);
                }
                catch(InvalidTypeFoodException itfe)
                { 
                    this.writre.WriteLine(itfe.Message);
                }
                catch(Exception ex )
                { 
                    this.writre.WriteLine(ex.ToString());
                } 
                
                animals.Add(animal);
            }

            foreach (IAnimal animal1 in animals)
            {
                this.writre.WriteLine(animal1.ToString());
            }
        }

        public IAnimal BildAnimalUsingAnimalFactory(string command)
        {
            string[] infoAnimal = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.CreateAnimal(infoAnimal);

            return animal;
        }

        public IFood BildFoodUsingFoodFactory()
        {
            string[] foodIfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string typeFood = foodIfo[0];
            int qty = int.Parse(foodIfo[1]);

            IFood food = foodFactory.CreateFood(typeFood,qty);

            return food;
        }
    }
}
