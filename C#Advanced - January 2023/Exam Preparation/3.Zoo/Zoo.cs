using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; }
        

        public string AddAnimal( Animal animal)
        {
            if(string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Capacity==Animals.Count)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }

        }

        public int RemoveAnimals( string species)
             => Animals.RemoveAll(s => s.Species == species);

        public List<Animal> GetAnimalsByDiet(string diet)
        => Animals.FindAll(s => s.Diet == diet);

        public Animal GetAnimalByWeight(double weight)
            => Animals.FirstOrDefault(a => a.Weigth == weight);

        public string GetAnimalCountByLength( double minimumLenght, double maximumLenght)
        {
            List<Animal> sortedAnimal = new List<Animal>();
            if (Animals.Count==0)
            {
                return $"There are {0} animals with a length between {minimumLenght} and {maximumLenght} meters.";
            }
            else
            {
                foreach (var animal in Animals)
                {
                    if (animal.Length >= minimumLenght && animal.Length <= maximumLenght)
                    {
                        sortedAnimal.Add(animal);
                    }
                }
            }
           

      

            return $"There are {sortedAnimal.Count} animals with a length between {minimumLenght} and {maximumLenght} meters.";
        }
    }
}
