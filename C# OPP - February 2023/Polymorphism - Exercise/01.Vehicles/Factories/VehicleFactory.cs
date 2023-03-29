using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Factories.Interfaces;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQty, double fuelConsumption)
        {
            if (type == "Car")
            {
                return new Car(fuelQty, fuelConsumption);

            }
            else if (type == "Truck")
            {
                return new Truck(fuelQty, fuelConsumption);
            }
            else
            {
                 throw new ArgumentException("Invalid vehicle type");
            }


        }
    }

}
