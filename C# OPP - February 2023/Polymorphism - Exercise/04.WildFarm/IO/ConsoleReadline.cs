using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class ConsoleReadline : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
