using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get { return cars; } set{ cars = value; } }

        public int Capacity { get { return capacity; } set { capacity = value; } }


        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        public int Count { get { return Cars.Count; } }

        public string AddCar( Car addCar)
        {
            bool canAddCar = true;
            foreach (var car in cars)
            {
                

                if (car.RegistrationNumber==addCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return $"Car with that registration number, already exists!";
                }
            }

            if (Cars.Count==Capacity)
            {
                canAddCar = false;
                return $"Parking is full!";
            }

            if (canAddCar)
            {
                Cars.Add(addCar);
                return $"Successfully added new car {addCar.Make} {addCar.RegistrationNumber}";
            }

            return "";
        }

        public string RemoveCar( string registrationNumber)
        {
            bool isavelabal = false;

            foreach (var car in cars)
            {
                if (car.RegistrationNumber==registrationNumber)
                {   
                    isavelabal = true;
                }
            }

            if (isavelabal)
            {
                Car carForReoved = cars.First(car => car.RegistrationNumber == registrationNumber);
                cars.Remove(carForReoved);
                return $"Successfully removed {registrationNumber}";
            }

            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
             
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.First(car => car.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber( List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}
