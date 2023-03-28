using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
      

        public Rectangle(double height, double width)
        {
            Height = height;
            Widht = width;
        }

        public double Height { get; private set; }
        public double Widht { get; private set; }

        public override double CalculateArea()
        {
            return Widht * Height;
        }

        public override double CalculatePerimeter()
        {
            return Widht * 2 + Height * 2;
        }
    

        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
