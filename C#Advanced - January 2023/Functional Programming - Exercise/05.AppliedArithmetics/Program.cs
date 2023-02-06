

Action<List<int>> printNumbers = n => Console.WriteLine(string.Join(" ", n));

Func<List<int>, string, List<int>> calulatenumbers = (numbers, command) =>
{
    List<int> result = new List<int>();

    foreach (var num in numbers)
    {
        switch (command)
        {
            case "add":
                result.Add(num + 1);
                break;
            case "multiply":
                result.Add(num * 2);
                break;
            case "subtract":
                result.Add(num - 1);
                break;
        }
    }

    return result;

};

List<int> numbres = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

string command = Console.ReadLine();

while (command != "end")
{
    if (command == "print")
    {
        printNumbers(numbres);
    }
    else
    {
        numbres = calulatenumbers(numbres, command);
    }

    command = Console.ReadLine();

}

