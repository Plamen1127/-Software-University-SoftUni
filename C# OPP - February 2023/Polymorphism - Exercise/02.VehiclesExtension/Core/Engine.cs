using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Exceptions;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicalFactory vehicalFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicalFactory vehicalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicalFactory = vehicalFactory;

            vehicles = new HashSet<IVehicle>();

        }

        public void Run()
        {
            this.vehicles.Add(this.BildVehicleUsingVehicalFactory());
            this.vehicles.Add(this.BildVehicleUsingVehicalFactory());
            this.vehicles.Add(this.BildVehicleUsingVehicalFactory());

            int times = int.Parse(reader.ReadLine());
            for (int i = 0; i < times; i++)
            {
                try
                {
                    this.ProcesComand();
                }
                catch (InsufficientFuelException ife)
                {

                    this.writer.WriteLine(ife.Message);
                }
                catch(InvalidVehicalTypeException ite) 
                { 
                    this.writer.WriteLine(ite.Message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }  
                 catch(MoreThanTheAllowedFuelException mttafe)
                {
                    this.writer.WriteLine(mttafe.Message);
                } 
                catch(Exception)
                {
                    throw;
                }
            }

            this.PrintAllvehicles();
        }

         
        private IVehicle BildVehicleUsingVehicalFactory()
        {
            string[] vehicleInf = reader.ReadLine().
                            Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleInf[0];
            double vehicleFuelQty = double.Parse(vehicleInf[1]);
            double vehicleLitersPerKm = double.Parse(vehicleInf[2]);
            double tangCapacity = double.Parse(vehicleInf[3]);

            IVehicle vehicle = vehicalFactory.CrietVeical(vehicleType, vehicleFuelQty, vehicleLitersPerKm, tangCapacity);

            return vehicle;
        }

        private void ProcesComand()
        {
            string[] cmdArg = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string comand = cmdArg[0];
            string typeVehicle = cmdArg[1];
            double arg = double.Parse(cmdArg[2]);

           IVehicle vehicleToProces = this.vehicles.FirstOrDefault(v => v.GetType().Name == typeVehicle);
            bool isEmpty = false;
            if (vehicleToProces == null)
            {
                throw new InvalidVehicalTypeException();
            }
            else if (comand == "Drive")
            {
                 this.writer.WriteLine(vehicleToProces.Drive(arg, isEmpty));
            }
            else if (comand == "DriveEmpty")
            {
                isEmpty = true;
              this.writer.WriteLine(vehicleToProces.Drive(arg, isEmpty));
            }
            else if (comand == "Refuel")
            {
                vehicleToProces.Refuel(arg);
            }
        }

        private void PrintAllvehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }
    }

}
