using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Exceptions
{
    public class InvalidTypeFoodException : Exception
    {
        public InvalidTypeFoodException(string text)
            :base(text)
        {

        }
        public InvalidTypeFoodException()
        {

        }
    }
}
