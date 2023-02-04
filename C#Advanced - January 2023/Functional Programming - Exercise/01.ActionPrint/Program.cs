using System;

Action<string[]> printName = x => Console.WriteLine(string.Join(Environment.NewLine, x));

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

printName(names);
//PrintNames(names);

//void PrintNames(string[] names)
//{
//    Console.WriteLine(string.Join(Environment.NewLine, names));
//}