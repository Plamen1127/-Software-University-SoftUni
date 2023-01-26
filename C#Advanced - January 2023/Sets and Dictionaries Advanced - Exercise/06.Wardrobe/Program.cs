using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = data[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < data.Length; j++)
                {
                    if (!clothes[color].ContainsKey(data[j]))
                    {
                        clothes[color].Add(data[j], 0);
                    }
                    clothes[color][data[j]]++;
                }
            }
           
            string[] chekDress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (var curentClolor in clothes)
            {
                Console.WriteLine($"{curentClolor.Key} clothes:");
                foreach (var curentClothes in curentClolor.Value)
                {
                    string printClothe = $"* {curentClothes.Key} - {curentClothes.Value}";

                    if (curentClolor.Key == chekDress[0] && curentClothes.Key == chekDress[1])
                    {
                        printClothe += $" (found!)";
                    }
                    Console.WriteLine(printClothe);
                }
            }
        }
    }
}
