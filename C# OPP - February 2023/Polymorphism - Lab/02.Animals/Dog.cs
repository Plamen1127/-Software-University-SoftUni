using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine( $"I am {Name} and my fovourite food is {FavouriteFood}");
            sb.Append("DJAAF");

            return sb.ToString().Trim();
        }   
    }
}
