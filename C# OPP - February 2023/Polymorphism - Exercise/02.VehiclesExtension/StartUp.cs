using System;
using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicalFactory vehicalFactory = new VehicalFactory();

            IEngine engine = new Engine(reader, writer, vehicalFactory);
            engine.Run();
        }
    }
}