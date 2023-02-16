

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace RawData;


public class StartUp
{
    static void Main(string[] args)
    {
        int times = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < times; i++)
        {
            string[] carsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(
                carsInfo[0],
                int.Parse(carsInfo[1]),
                int.Parse(carsInfo[2]),
                int.Parse(carsInfo[3]),
                carsInfo[4],
                double.Parse(carsInfo[5]),
                int.Parse(carsInfo[6]),
                double.Parse(carsInfo[7]),
                int.Parse(carsInfo[8]),
                double.Parse(carsInfo[9]),
                int.Parse(carsInfo[10]),
                double.Parse(carsInfo[11]),
                int.Parse(carsInfo[12]));

            cars.Add(car);
        }

        string command = Console.ReadLine();

        string[] filtersCars;


        if (command == "fragile")
        {
            filtersCars = cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.TirePressure < 1))
                .Select(m => m.Model)
                .ToArray();

        }
        else 
        {
            filtersCars = cars
                .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                .Select(c => c.Model)
                .ToArray();
        }

        Console.WriteLine(string.Join(Environment.NewLine, filtersCars));

    }
}


