

Action<List<string>, Predicate<string>> printFilterNames = (names, match) =>
{
    foreach (var name in names)
    {
        if (match(name))
        {
            Console.WriteLine(name);
        }
    }
};
int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Predicate<string> match = name => name.Length <= n;
printFilterNames(names, match);
