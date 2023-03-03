using System;
using System.Drawing;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Cat cat = new Cat();

            cat.Eat();
            cat.Meow();

        }
    }
}
