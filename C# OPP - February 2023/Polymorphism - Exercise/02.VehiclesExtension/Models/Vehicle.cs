using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Exceptions;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public class Vehicle : IVehicle
    {

        private double fuelConsumptionIncrament;

        public Vehicle(double fuelQty, double fuelConsumption, double tangCapacity, double fuelConsumptionIncrament)
        {
            this.FuelQty = fuelQty;
            this.FuelConsumption = fuelConsumption ;
            this.TangCapacity = tangCapacity;
            this.fuelConsumptionIncrament = fuelConsumptionIncrament;   

        }


        public double FuelQty { get; private set; }

        public double FuelConsumption { get; private set; }

        public double TangCapacity { get; private set; }
        


        public string Drive(double distance, bool isEmpty)
        {
            double neededFuel;
            if (isEmpty)
            {
                neededFuel = distance * FuelConsumption;
            }
            else 
            {
                neededFuel = distance * (FuelConsumption + fuelConsumptionIncrament);
            }

            if (neededFuel > FuelQty)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMesegges.InsufficientFuelException, GetType().Name));
            }

            FuelQty -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(string.Format(ExceptionMesegges.FuelMustBeAPositivNumber));
            }
            double tryToAddFuel = liters + FuelQty;
            if (tryToAddFuel > this.TangCapacity)
            {
                throw new MoreThanTheAllowedFuelException(string.Format(ExceptionMesegges.MoreThanTheAllowedFuelException, liters));
            }
            FuelQty += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:f2}";
        }
    }
}
