using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Exceptions;
using WildFarm.Factory.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Factory
{
    public class AnimalsFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] info)
        {
            string animalType = info[0];
            string animalName = info[1];
            double animalWeight = double.Parse(info[2]);

            IAnimal animal;
            
            if (animalType== "Hen")
            {
                double wingSize = double.Parse(info[3]);

                animal = new Hen(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(info[3]);

                animal = new Owl(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livinRegion = info[3];

                animal = new Mouse(animalName, animalWeight, livinRegion);
            }
            else if (animalType== "Dog")
            {
                string livinRegion = info[3];

                animal = new Dog(animalName, animalWeight, livinRegion);
            }
            else if (animalType == "Cat")
            {
                string livinRegion = info[3];
                string breed = info[4];

                animal = new Cat(animalName, animalWeight, livinRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livinRegion = info[3];
                string breed = info[4];

                animal = new Tiger(animalName, animalWeight, livinRegion, breed);
            }
            else
            {
                throw new InvalidAnimalTypeException(string.Format(ExceptionsMessages.InvalidAnimalType));
            }

            return animal;
        }
    }
}
