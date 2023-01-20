using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            numbers = numbers.OrderByDescending(n => n).ToList();

            if (numbers.Count < 3)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write($"{numbers[i]} ");
                }
                
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{numbers[i]} ");

                }
            }

        }
    }
}
