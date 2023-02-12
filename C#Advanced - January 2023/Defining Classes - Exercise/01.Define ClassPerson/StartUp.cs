using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new();

            person.Name = "Plamen";
            person.Age = 37;

            Console.WriteLine($"My name i {person.Name} and I'm {person.Age} years old.");
        }
    }
}
