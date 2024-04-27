using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheyAreBillions.Classes
{
    public class WetherStation
    {
        public void AddData(double val)
        {
            if (val < this.Min)
            {
                this.Min = val;
            }
            if (val > this.Max)
            {
                this.Max = val;
            }
            Sum += val;
            Count++;
        }

        //public string Name { get; set; }
        public double Min { get; set; } = double.MaxValue;
        public double Max { get; set; }
        public double Sum { get; set; }
        public int Count { get; set; }

    }

    public static class WetherExtension
    {
        public static void CreateOrAddToExist(this IDictionary<string, WetherStation> dict, string key, double value)
        {
            key ??= string.Empty;

            if (!dict.TryGetValue(key, out WetherStation val))
            {
                val = new WetherStation();
                dict.Add(key, val);
            }
            val.AddData(value);
        }

        public static void WroteAll(this IDictionary<string, WetherStation> dict)
        {
            var ordered = dict.OrderBy(p => p.Key);
            foreach (var kvp in ordered)
            {
                Console.WriteLine($"{kvp.Key} - Min: {kvp.Value.Min}, Max: {kvp.Value.Max}, Mean: {kvp.Value.Sum / kvp.Value.Count: #:0}, Count: {kvp.Value.Count}");
            }
        }
    }
}
