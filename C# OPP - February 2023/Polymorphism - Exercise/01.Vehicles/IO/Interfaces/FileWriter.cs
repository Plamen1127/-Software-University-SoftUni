using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.IO.Interfaces
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string str)
        {
            using StreamWriter writer = new("D:\\test.txt", true);

            writer.WriteLine(str);
        }
    }
}
