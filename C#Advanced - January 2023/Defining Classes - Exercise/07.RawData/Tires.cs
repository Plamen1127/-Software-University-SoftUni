using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData;

public class Tires
{
    public Tires(double tirePressure,int tireAge)
    {
        TirePressure = tirePressure;
        TireAge = tireAge;
    }

    public double TirePressure { get; set; }
    public int TireAge { get; set; }
}

