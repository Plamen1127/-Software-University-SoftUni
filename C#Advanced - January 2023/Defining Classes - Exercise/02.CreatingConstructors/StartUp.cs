using DefiningClasses;
using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new();
            Person person1 = new();

           person1.Name="Plamen";

            Console.WriteLine($"My name i {person.Name} and I'm {person.Age} years old.");
            Console.WriteLine($"My name i {person1.Name} and I'm {person1.Age} years old.");
        }
    }
}
