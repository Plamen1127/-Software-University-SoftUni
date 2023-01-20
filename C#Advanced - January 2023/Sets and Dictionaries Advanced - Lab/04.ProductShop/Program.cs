using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] command = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string nameShop = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);

                if (!shops.ContainsKey(nameShop))
                {
                    shops.Add(nameShop, new Dictionary<string, double>());
                }

                shops[nameShop].Add(product, price);

                input = Console.ReadLine();
            }

            shops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in shops)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
