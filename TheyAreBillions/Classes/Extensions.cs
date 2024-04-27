using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheyAreBillions.Classes
{
    public static class ParsedDataExtension
    {
        //public static void ParsedData(this ParsedData parsed, string? data)
        //{
        //    string[] strings = data!.Split(';');

        //    var num = double.Parse(strings[1], CultureInfo.InvariantCulture);
        //    parsed.Station = strings[0];
        //    parsed.Temperature = num;
        //}
    }
    public static class WetherExtension
    {
        //public static void CreateOrAddToExist(this IDictionary<string, WetherStation> dict, string key, double value)
        //{
        //    key ??= string.Empty;

        //    if (!dict.TryGetValue(key, out WetherStation val))
        //    {
        //        val = new WetherStation();
        //        dict.Add(key, val);
        //    }
        //    val.AddData(value);
        //}

        public static void WroteAll(this IDictionary<string, WetherStation> dict)
        {
            var ordered = dict.OrderBy(p => p.Key);
            foreach (var kvp in ordered)
            {
                Console.WriteLine($"{kvp.Key} - Min: {kvp.Value.Min}, Max: {kvp.Value.Max}, Mean: {kvp.Value.Sum / kvp.Value.Count: 0.0}, Count: {kvp.Value.Count}");
            }
        }
    }
}
