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

    public static class ParsedDataExtension
    {
        public static void ParsedData(this ParsedData parsed, string? data)
        {
            string[] strings = data!.Split(';');

            var num = double.Parse(strings[1], CultureInfo.InvariantCulture);
            parsed.Station = strings[0];
            parsed.Temperature = num;
        }
    }
}
