using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrament = 1.4;

        public Bus(double fuelQty, double fuelConsumption, double tangCapacity) 
            : base(fuelQty, fuelConsumption, tangCapacity, fuelConsumptionIncrament)
        {

        }

    }
}
