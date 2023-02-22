


int[] dataCoffeines = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] dataDrinks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Stack<int> coffeine = new Stack<int>(dataCoffeines);
 Queue<int> drink = new Queue<int>(dataDrinks);

int curentCoffeine = 0;

while (coffeine.Count>0 && drink.Count>0)
{
    int lastCoffeine = coffeine.Pop();
    int firstDrink = drink.Dequeue();

    int multiplayCoffeineAndDrink = lastCoffeine * firstDrink;

    if (multiplayCoffeineAndDrink+curentCoffeine <= 300)
    {
        curentCoffeine += multiplayCoffeineAndDrink;
    }

    else
    {
        if (curentCoffeine<30)
        {
            curentCoffeine = 0;
        }
        else
        {
            curentCoffeine -= 30;
        }
       
        drink.Enqueue(firstDrink);
    }
}

if (drink.Count>0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", drink)}");
}
else
{
    Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {curentCoffeine} mg caffeine.");

