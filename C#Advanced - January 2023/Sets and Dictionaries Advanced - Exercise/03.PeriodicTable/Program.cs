using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                for (int j = 0; j < data.Length; j++)
                {
                    elements.Add(data[j]);
                }
            }
            
            Console.Write(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
