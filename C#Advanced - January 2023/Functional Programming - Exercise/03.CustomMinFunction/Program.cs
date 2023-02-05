using System;

Func<int[], int> smallestNumber = n =>
{
    int smallesNum = int.MaxValue;

    foreach (var num in n)
    {
        if (num < smallesNum)
        {
            smallesNum = num;
        }

    }

    return smallesNum;
};

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(smallestNumber(numbers));
