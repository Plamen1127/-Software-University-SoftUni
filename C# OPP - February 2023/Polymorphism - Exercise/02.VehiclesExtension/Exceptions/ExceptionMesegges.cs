using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Exceptions
{
    public static class ExceptionMesegges
    {
        public const string InsufficientFuelException = "{0} needs refueling";

        public const string MoreThanTheAllowedFuelException = "Cannot fit {0} fuel in the tank";

        public const string FuelMustBeAPositivNumber = "Fuel must be a positive number";
    }
}
