

using System;
using Vehicle.Models.Interfaces;

namespace Vehicle.Models
{
    public abstract class Vehicle : IVehicle
    {
        

        protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumptionIncrement)
        {
            
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + increasedConsumptionIncrement;
            
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }



        public string Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (fuelNeeded>FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

    }
}
