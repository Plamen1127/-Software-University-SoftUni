using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories.Interfaces
{
    public interface IVehicalFactory
    {
        IVehicle CrietVeical(string type, double fuelQty, double literPerKm, double tangCapacity);
    }
}
