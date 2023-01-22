using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < times; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string continent = data[0];
                string countre = data[1];
                string sity = data[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(countre))
                {
                    continents[continent].Add(countre, new List<string>());
                }

                continents[continent][countre].Add(sity);

            }

            foreach (var curenContinent in continents)
            {
                Console.WriteLine($"{curenContinent.Key}:");

                foreach (var country in curenContinent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
