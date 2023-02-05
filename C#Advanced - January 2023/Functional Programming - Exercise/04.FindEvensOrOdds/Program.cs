using Microsoft.VisualBasic;
using System;

int[] range = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string command = Console.ReadLine();

Func<int, int, List<int>> generiteRange = (start, end) =>
{
    List<int> range = new();

    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }

    return range;
};

List<int> numbers = generiteRange(range[0], range[1]);

Predicate<int> match;

if (command == "odd")
{
    match = n => n % 2 != 0;
}
else
{
    match = n => n % 2 == 0;
}

List<int> result = new List<int>();

foreach (var num in numbers)
{
    if (match(num))
    {
        result.Add(num);
    }
}

//Predicate<int> matchodd = n => n % 2 != 0;
//Predicate<int> matcheven = n => n % 2 == 0;

//List<int> result = new List<int>();

//foreach (var num in numbers)
//{
//    if (command == "odd")
//    {
//        if (matchodd(num))
//        {
//            result.Add(num);
//        }
//    }
//    else if (command == "even")
//    {
//        if (matcheven(num))
//        {
//            result.Add(num);
//        }
//    }
//}

Console.WriteLine(string.Join(" ", result));