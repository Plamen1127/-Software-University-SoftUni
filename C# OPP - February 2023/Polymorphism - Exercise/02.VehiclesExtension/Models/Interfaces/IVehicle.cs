using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQty { get; }

        public double FuelConsumption { get; }

        public double TangCapacity { get; }

        public string Drive(double distance, bool isEmpty);

        public void Refuel(double liters);
    }
}
