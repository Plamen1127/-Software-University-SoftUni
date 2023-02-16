using DefiningClasses;
using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = people[0];
                int age = int.Parse(people[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
   

            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
