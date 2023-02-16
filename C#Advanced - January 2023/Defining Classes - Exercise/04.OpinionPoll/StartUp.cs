using DefiningClasses;
using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> peopleOver30Year = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);

                if (age>30)
                {
                    Person person = new Person(name, age);
                    peopleOver30Year.Add(person);
                }
            }

            foreach (var person in peopleOver30Year.OrderBy(a=>a.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}