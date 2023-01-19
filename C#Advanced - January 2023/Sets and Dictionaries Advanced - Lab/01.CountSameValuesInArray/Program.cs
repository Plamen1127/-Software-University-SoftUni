using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numberRepeated = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberRepeated.ContainsKey(number))
                {
                    numberRepeated.Add(number, 0);
                }

                numberRepeated[number] += 1;
            }

            foreach (var curentNumber in numberRepeated)
            {
                Console.WriteLine($"{curentNumber.Key} - {curentNumber.Value} times");
            }
        }
    }
}
