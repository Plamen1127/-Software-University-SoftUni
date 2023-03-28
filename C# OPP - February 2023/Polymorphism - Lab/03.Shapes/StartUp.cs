using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circule = new Circle(2.5);
            Shape rectangel = new Rectangle(2.5, 2.5);

            Console.WriteLine(circule.CalculateArea());
            Console.WriteLine(circule.Draw());
        }
    }
}
