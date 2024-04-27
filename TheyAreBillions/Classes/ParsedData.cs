using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheyAreBillions.Classes
{
    public class ParsedData
    {
        public ParsedData()
        {
        }

        public ParsedData(string station, double temperature)
        {
            Station = station;
            Temperature = temperature;
        }

        public string Station { get; set; }
        public double Temperature { get; set; }
    }
}
