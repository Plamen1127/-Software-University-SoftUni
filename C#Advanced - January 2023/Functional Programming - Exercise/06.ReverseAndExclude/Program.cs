

Func<List<int>, List<int>> reverseNumbers = n =>
{
    List<int> result = new List<int>();

    for (int i = n.Count - 1; i >= 0; i--)
    {
        result.Add(n[i]);
    }

    return result;
};


Func<List<int>, Predicate<int>, List<int>> excludeDivisible = (numbers, match) =>
{
    List<int> result = new List<int>();

    foreach (var num in numbers)
    {
        if (match(num))
        {
            result.Add(num);
        }
    }

    return result;
};

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divisible = int.Parse(Console.ReadLine());

Predicate<int> match = n => n % divisible != 0;
Action<List<int>> printNumbers = n => Console.WriteLine(string.Join(" ", numbers));

numbers = reverseNumbers(numbers);
numbers = excludeDivisible(numbers, match);
printNumbers(numbers);