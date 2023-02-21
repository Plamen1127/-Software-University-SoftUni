


using System.Collections.Specialized;
using System.Linq;

int[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Dictionary<string, int> elements = new Dictionary<string, int>();
elements.Add("Patch", 0); //30
elements.Add("Bandage", 0); //40
elements.Add("MedKit", 0); //100



Queue<int> textiles = new Queue<int>(input1);
Stack<int> medicaments = new Stack<int>(input2);


while (textiles.Count > 0 && medicaments.Count > 0)
{
	int firstdecue = textiles.Dequeue();
	int lastStack = medicaments.Pop();
	int sum = firstdecue + lastStack;

	if (sum == 30)
	{
		elements["Patch"]++;
	}
	else if (sum == 40)
	{
		elements["Bandage"]++;
	}
	else if (sum == 100)
	{
		elements["MedKit"]++;
	}
	else if (sum > 100)
	{
		elements["MedKit"]++;
		int left = sum - 100;
		int takeNex = medicaments.Pop();
		medicaments.Push(left+takeNex);
	}
	else
	{
		medicaments.Push(lastStack + 10);
	}
}

	if (textiles.Count==0 && medicaments.Count > 0)
	{
		Console.WriteLine("Textiles are empty.");
	}
	else if (medicaments.Count==0 && textiles.Count> 0)
	{
		Console.WriteLine("Medicaments are empty.");

    }
	else if (medicaments.Count == 0 && textiles.Count== 0)
	{
		Console.WriteLine("Textiles and medicaments are both empty.");
	}

Dictionary<string, int> sort = elements.OrderByDescending(e => e.Value).ThenBy(e => e.Key).ToDictionary(x => x.Key, x => x.Value);


foreach (var element in sort)
{
	if (element.Value>0)
	{
        Console.WriteLine($"{element.Key} - {element.Value}");
    }
	
}


if (medicaments.Count > 0 )
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");

}
else if (textiles.Count > 0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}

