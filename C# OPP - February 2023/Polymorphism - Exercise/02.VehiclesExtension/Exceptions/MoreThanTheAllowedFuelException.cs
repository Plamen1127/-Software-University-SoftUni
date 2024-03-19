using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Exceptions
{
    public class MoreThanTheAllowedFuelException : Exception
    {
        public MoreThanTheAllowedFuelException()
        {
        }

        public MoreThanTheAllowedFuelException( string message)
            :base(message)
        {

        }
    }
}
