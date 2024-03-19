using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Exceptions;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Models;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories
{
    internal class VehicalFactory : IVehicalFactory
    {
        public IVehicle CrietVeical(string type, double fuelQty, double literPerKm, double tangCapacity)
        {
            if (fuelQty > tangCapacity)
            {
                fuelQty = 0;
            }

            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty, literPerKm, tangCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, literPerKm, tangCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQty, literPerKm, tangCapacity);
            }
            else
            {
                throw new InvalidVehicalTypeException();
            }

            return vehicle;
        }
    }
}
