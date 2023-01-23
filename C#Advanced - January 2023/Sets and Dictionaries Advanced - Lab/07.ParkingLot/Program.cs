using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] command = input.Split(", ");

                if (command[0] == "IN")
                {
                    carsNumbers.Add(command[1]);
                }
                else
                {
                    carsNumbers.Remove(command[1]);
                }

                input = Console.ReadLine();
            }

            if (carsNumbers.Count > 0)
            {
                foreach (var numberCar in carsNumbers)
                {
                    Console.WriteLine(numberCar);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
