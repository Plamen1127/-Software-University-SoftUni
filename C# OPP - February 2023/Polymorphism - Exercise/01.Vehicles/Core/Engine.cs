using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Interfaces;
using Vehicle.Factories.Interfaces;
using Vehicle.IO.Interfaces;
using Vehicle.Models.Interfaces;

namespace Vehicle.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            this.vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandsTimes = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsTimes; i++)
            {
                try
                {
                    ProcessCommand();

                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }

        }


        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
        }


        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commmand = commandTokens[0];
            string vihicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vihicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (commmand=="Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }

            else if (commmand=="Refuel")
            {
                double fuelAmount = double.Parse(commandTokens[2]);
                vehicle.Refuel(fuelAmount);
            }
        }
    }
}
