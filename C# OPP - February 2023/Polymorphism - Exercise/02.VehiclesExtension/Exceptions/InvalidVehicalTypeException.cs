using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Exceptions
{
    public class InvalidVehicalTypeException : Exception
    {
        private const string DefoltMeessage = "Vehicle type not suport";
        public InvalidVehicalTypeException():
            base(DefoltMeessage)
        {

        }
        public InvalidVehicalTypeException(string text)
            : base(text)
        {

        }
    }
}
