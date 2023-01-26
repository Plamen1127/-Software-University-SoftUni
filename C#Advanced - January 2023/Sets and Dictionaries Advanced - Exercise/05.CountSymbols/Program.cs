using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!characters.ContainsKey(input[i]))
                {
                    characters.Add(input[i], 0);
                }
                characters[input[i]]++;
            }

            foreach (var curentChar in characters)
            {
                Console.WriteLine($"{curentChar.Key}: {curentChar.Value} time/s");
            }
        }
    }
}
