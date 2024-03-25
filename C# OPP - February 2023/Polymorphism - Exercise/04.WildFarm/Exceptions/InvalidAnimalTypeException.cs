using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Exceptions
{
    public class InvalidAnimalTypeException: Exception
    {
        public InvalidAnimalTypeException( string text)
            :base(text)
        {

        }
    }
}
