// See https://aka.ms/new-console-template for more information
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
//using var reader = new StreamReader(file, System.Text.Encoding.UTF8);
Stopwatch stopwatch = Stopwatch.StartNew();

Dictionary<string, WetherStation> wetherStations = new();


var readed = ReadRows(file);

var parsed = ProccessRows(readed);

foreach (var row in parsed)
{
    wetherStations.CreateOrAddToExist(row.Station, row.Temperature);
}

//var enumeratorParsed = parsed.GetEnumerator();
//while (enumeratorParsed.MoveNext())
//{
//    Consts.AddedLineNumber++;
//    if (Consts.AddedLineNumber % 10_000_000 == 0)
//    {
//        Console.WriteLine("read" + Consts.AddedLineNumber);
//    }
//    var row = enumeratorParsed.Current;
//    wetherStations.CreateOrAddToExist(row.Station, row.Temperature);
//}
wetherStations.WroteAll();
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds / 1_000);
Console.WriteLine("ende");

static ParsedData ParsedData(string? data)
{
    string[] strings = data!.Split(';');

    var num = double.Parse(strings[1], CultureInfo.InvariantCulture);
    //if (num == 99.9 || num == -99.9)
    //{
    //    Console.WriteLine(strings[0]);
    //}

    return new ParsedData(strings[0], num);
}

static IEnumerable<string> ReadRows(StreamReader reader)
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        Consts.ReadLineNumber++;
        if (Consts.ReadLineNumber % 1_000_000 == 0)
        {
            Console.WriteLine("read" + Consts.ReadLineNumber);
        }
        //if (Consts.ReadLineNumber % 100_000_000 == 0)
        //{
        //    //Console.WriteLine(Consts.LineNumber);
        //    break;
        //}

        yield return line;


        //Console.WriteLine(ss);
    }
}

static IEnumerable<ParsedData> ProccessRows(IEnumerable<string> reader)
{
    foreach (var row in reader)
    {
        yield return ParsedData(row);
    }


    //var enumeratorReaded = reader.GetEnumerator();
    //while (enumeratorReaded.MoveNext())
    //{
    //    Consts.ParseLineNumber++;
    //    if (Consts.ParseLineNumber % 10_000_000 == 0)
    //    {
    //        Console.WriteLine("preces" + Consts.ParseLineNumber);
    //    }
    //    //var row = enumerator.Current;
    //    yield return ParsedData(enumeratorReaded.Current);
    //    //wetherStations.CreateOrAddToExist(row.Station, row.Temperature);
    //}
}