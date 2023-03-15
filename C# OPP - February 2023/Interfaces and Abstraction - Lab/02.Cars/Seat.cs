using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return $"{Color} Seat {Model}";
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