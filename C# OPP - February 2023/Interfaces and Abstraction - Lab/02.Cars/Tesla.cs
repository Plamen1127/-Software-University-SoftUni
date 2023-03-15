using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battry)
        {
            Model = model;
            Color = color;
            Battery = battry;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }

        public string Start()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}