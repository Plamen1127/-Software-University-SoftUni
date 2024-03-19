using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionIncrament = 0.9;

        public Car(double fuelQty, double fuelConsumption, double tangCapacity) 
            : base(fuelQty, fuelConsumption, tangCapacity,FuelConsumptionIncrament)
        {

        }
    }
}
