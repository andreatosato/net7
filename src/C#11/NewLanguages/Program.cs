//UTF - 8 string literals
//By default C# strings are hardcoded to UTF-16
/*
var myBufferArray = "hello world!"u8.ToArray();
foreach (var c in myBufferArray)
{
    // https://alpharithms.s3.amazonaws.com/assets/img/ascii-chart/ascii-table-alpharithms-scaled.jpg
    Console.WriteLine(c);
}
*/

//// Raw string literals
//// This\is\all "content"!
//var mySimpleSample = """This\is\all "content"!""";
//Console.WriteLine(mySimpleSample);
//// Voglio scrivere ", "", """ o eventualmente """" double quotes!
//var myLessSimpleSample = """""Voglio scrivere ", "", """ o eventualmente """" double quotes!""""";
//Console.WriteLine(myLessSimpleSample);


// required

//using System.Diagnostics.CodeAnalysis;

//var c = new Course { Name = "Matematica", StartDate = DateTime.UtcNow };
//Console.WriteLine(c);
//var c2 = new Course { Name = null, StartDate = DateTime.UtcNow };
//Console.WriteLine(c2);
//var c3 = new Course("informatica") { StartDate = DateTime.UtcNow };
//Console.WriteLine(c3);


//Console.ReadLine();


// Order
//var listInt = new[] { 23, 11, 1, -2, 3, -4, 55, 6 };
//var ordered = listInt.Order();
//foreach (var o in ordered)
//{
//    Console.WriteLine(o);
//}


// list pattern matching
//var list = new[] { 1, 2, 3, 4, 5, 6, 7, 11, 9 };
//var isTrue = list is [1, 2, 3, 4, 5, 6, 7, _, 9];
//Console.WriteLine(isTrue);

//var list2 = new List<int>() { 1, 2, 33, -55, 3, 4, 5, 6, 7, 11, 9 };
//var isTrue2 = list2 is [1, .., 4, 5, 6, 7, _, 9];
//Console.WriteLine(isTrue2);

//var list3 = new[] { 1, 2, 3 };

//var result = list3 switch
//{
//    [] => 1,
//    [var first] => first,
//    [var first, var second] => second,
//    [var _, var _, var _, var _, .. var rest] => rest.Last(),
//    _ => 2
//};
//Console.WriteLine(result);


// Time
//Console.WriteLine(DateTime.UtcNow.TimeOfDay.Microseconds);
//Console.WriteLine(DateTime.UtcNow.TimeOfDay.Nanoseconds);
//// TimeOnly
//Console.WriteLine(TimeOnly.FromDateTime(DateTime.UtcNow));
//Console.WriteLine(JsonSerializer.Serialize(new TimeOnly(23, 59, 59, 01, 02)));

//// 128 bit
//var maxNum = Int128.MaxValue;
//Console.WriteLine(maxNum);
//var uMaxNum = UInt128.MaxValue;
//Console.WriteLine(uMaxNum);


//public class Course
//{
//    public required string Name { get; init; }
//    public string Description { get; set; } = null!;
//    public required DateTime StartDate { get; set; }

//    public Course()
//    {

//    }

//    [SetsRequiredMembers()]
//    public Course(string name)
//    {
//        Name = name;
//    }

//    public override string ToString()
//    {
//        return $"{Name} {StartDate.ToShortDateString()}";
//    }
//}

// Abstract interface
//public interface IStorage
//{
//    List<FileAb> Files { get; }
//    void AddFile(byte[] data)
//    {
//        Files.Add(new FileAb { Name = $"{DateTime.Now.ToLongDateString()}", Data = data });
//    }
//    abstract Task DeleteFiles(string name);
//    Task<int> SaveAsync();
//}

//public class AzureStorage : IStorage
//{
//    public AzureStorage()
//    {
//        Files = new List<FileAb>();
//    }
//    public List<FileAb> Files { get; }

//    public Task DeleteFiles(string name)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<int> SaveAsync()
//    {
//        throw new NotImplementedException();
//    }
//}


//public class FileAb
//{
//    public string Name { get; set; }
//    public byte[] Data { get; set; }
//}


//using System.Text.Json;
//using System.Text.Json.Serialization;

//var vehicle = new Vehicle()
//{
//    Name = "Boing",
//    Tires = new[] { new Tire { Pressure = 2.99m }, new Tire { Pressure = 2.99m } }.ToList(),
//};
//WriteJson(vehicle);

//var car = new Car()
//{
//    Name = "Ferrari",
//    Spaces = 2,
//    Tires = new Tire[] {
//        new TireSpecial { Pressure = 2m, Name = "Bridgeston" },
//        new TireSpecial { Pressure = 2m, Name = "Bridgeston" },
//        new TireSpecial { Pressure = 2m, Name = "Bridgeston" },
//        new TireSpecial { Pressure = 2m, Name = "Bridgeston" }
//    }.ToList(),
//};
//WriteJson(car);

//var bike = new Bike { Name = "Bianchi", Weight = 8500, Tires = new[] { new Tire { Pressure = 8 }, new Tire { Pressure = 8m } }.ToList() };
//WriteJson(bike);


//void WriteJson(Vehicle v)
//{
//    Console.WriteLine(JsonSerializer.Serialize((object)v, new JsonSerializerOptions { WriteIndented = true }));
//}

//// JSON
//[JsonDerivedType(typeof(Car))]
//[JsonDerivedType(typeof(Bike))]
//public class Vehicle
//{
//    public string Name { get; set; } = null!;
//    public virtual List<Tire> Tires { get; set; } = new List<Tire>();
//}

//public class Car : Vehicle
//{
//    public int Spaces { get; set; }
//}

//public class Bike : Vehicle
//{
//    public int Weight { get; set; }
//}

//[JsonDerivedType(typeof(TireSpecial))]
//public class Tire
//{
//    public required decimal Pressure { get; set; }
//}

//public class TireSpecial : Tire
//{
//    public string Name { get; set; } = null!;
//}
