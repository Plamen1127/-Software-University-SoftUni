using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;
using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHerosFactory herosFactory = new HerosFactory();

           IEngine engine = new Engine(reader, writer, herosFactory);

            engine.Run();
        }
    }
}
