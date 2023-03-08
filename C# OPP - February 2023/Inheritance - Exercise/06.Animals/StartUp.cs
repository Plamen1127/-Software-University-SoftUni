using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            while (animalType!= "Beast!")
            {
                string[] dataAnimal = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string namesAnimal = dataAnimal[0];
                int ageForAnimal = int.Parse(dataAnimal[1]);
                string gender = dataAnimal[2];

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(namesAnimal, ageForAnimal, gender);
                            PrintAnimal<Dog>(dog);
                            break;

                        case "Frog":
                            Frog frog = new Frog(namesAnimal, ageForAnimal, gender);
                            PrintAnimal<Frog>(frog);
                            break;

                        case "Cat":
                            Cat cat = new Cat(namesAnimal, ageForAnimal, gender);
                            PrintAnimal<Cat>(cat);
                            break;

                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(namesAnimal, ageForAnimal);
                            PrintAnimal<Tomcat>(tomcat);
                            break;

                        case "Kitten":
                            Kitten kitten = new Kitten(namesAnimal, ageForAnimal);
                            PrintAnimal<Kitten>(kitten);
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }
        }
        public static void PrintAnimal<T>( T animal)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine(animal.ToString());
        }
    }
}
