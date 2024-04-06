using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string name;
        private string model;
        private string licensePlateNumber;
        private bool isDamaged;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;

            BatteryLevel = 100;
        }

        public string Brand
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                name = value;
            }
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage {get; private set;}

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel {get; private set;}

        public bool IsDamaged
        {
            get { return IsDamaged; } 
        }
        public void ChangeStatus()
        {
            isDamaged = !IsDamaged;
        }

        public  void Drive(double mileage)
        {
            int decreasePercentage = (int)Math.Round(mileage / MaxMileage * 100);
            BatteryLevel -= decreasePercentage;

            if (this.GetType().Name == typeof(CargoVan).Name)
            {
                BatteryLevel -= 5;
            }
        }
        

        public void Recharge()
        {
             BatteryLevel = 100;
        }

        public override string ToString()
        {
            string curruntStatus = isDamaged ? "Ok" : "damaged";
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {curruntStatus}";
        }
    }
}
