// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.PortableExecutable;
using TheyAreBillions;
using TheyAreBillions.Classes;

Console.WriteLine("Hello, World!");

Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../generator/data/measurements.txt");

Console.WriteLine(path);
Console.WriteLine(File.Exists(path));
using var file = File.OpenText(path);
using FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
using BufferedStream bs = new BufferedStream(fs, 81920);
using StreamReader sr = new StreamReader(bs);
//using var reader = new StreamReader(file, System.Text.Encoding.UTF8);
Stopwatch stopwatch = Stopwatch.StartNew();

ConcurrentDictionary<string, WetherStation> wetherStations = new();

ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
ParallelOptions parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 8 };
Parallel.ForEach(ReadRows(sr), parallelOptions, (line, _, lineNumber) =>
{
    var row = ParsedData(line);
    wetherStations.AddOrUpdate(row.Station, new WetherStation(row.Temperature), (_, s) => s.AddDataAndReturn(row.Temperature));
});

//wetherStations.WroteAll();
stopwatch.Stop();
Console.WriteLine("watches " + stopwatch.ElapsedMilliseconds.ToString("###_000"));
Console.WriteLine("ende");

static ParsedData ParsedData(string? data)
{
    string[] strings = data!.Split(';');

    var num = double.Parse(strings[1], CultureInfo.InvariantCulture);

    return new ParsedData(strings[0], num);
}

static IEnumerable<string> ReadRows(StreamReader reader)
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        Consts.ReadLineNumber++;
        //if (Consts.ReadLineNumber % 10_000_000 == 0)
        //{
        //    Console.WriteLine("read" + Consts.ReadLineNumber);

        //    if (Consts.ReadLineNumber % 100_000_000 == 0)
        //    {
        //        break;
        //    }
        //}

        yield return line;

    }
}