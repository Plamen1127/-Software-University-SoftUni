using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedConsumptionIncrement = 0.9;

        public Car(double fuelQuantity, double fuelConsumption ) : base(fuelQuantity, fuelConsumption, IncreasedConsumptionIncrement)
        {
        }
    }
}
