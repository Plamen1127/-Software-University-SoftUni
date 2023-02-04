using System;
using System.Xml.Linq;

Action<string[]> printNames = names =>
{
	foreach (var name in names)
	{
		Console.WriteLine($"Sir {name}");
	}
};

string[] names = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.ToArray();

printNames(names);

//PrintNames(names);

//void PrintNames(string[] names)
//{
//    foreach(var name in names)
//	{
//        Console.WriteLine($"Sir {name}");
//    }
//}