using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheyAreBillions.Classes
{
    public struct ParsedData
    {
        public ParsedData()
        {
        }

        public ParsedData(string station, double temperature)
        {
            Station = station;
            Temperature = temperature;
        }

        public string Station { get; }
        public double Temperature { get; }
    }
}
