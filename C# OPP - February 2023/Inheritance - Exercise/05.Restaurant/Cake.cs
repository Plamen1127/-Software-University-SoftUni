using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GramsCake = 250;
        private const double CaloriesCake = 1000;
        private const decimal PriceCake = 5;


        public Cake(string name) : base(name, PriceCake, GramsCake, CaloriesCake)
        {
        }

      
    }
}
