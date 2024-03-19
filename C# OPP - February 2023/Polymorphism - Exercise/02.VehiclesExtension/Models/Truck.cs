using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Exceptions;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {

        private const double FuelConsumptionIncrament = 1.6;
        public Truck(double fuelQty, double fuelConsumption, double tangCapacity) 
            : base(fuelQty, fuelConsumption,  tangCapacity, FuelConsumptionIncrament)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters > this.TangCapacity)
            {
                throw new MoreThanTheAllowedFuelException(string.Format(ExceptionMesegges.MoreThanTheAllowedFuelException, liters));
            }
            base.Refuel(liters*0.95);
        }
    }
}
