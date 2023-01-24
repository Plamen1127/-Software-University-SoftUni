using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nM = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            HashSet<int> numbersN = new HashSet<int>();
            HashSet<int> numbersM = new HashSet<int>();

            for (int i = 0; i < nM[0] + nM[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i < nM[0])
                {
                    numbersN.Add(num);
                }
                else
                {
                    numbersM.Add(num);
                }
            }

            foreach (var n in numbersN)
            {
                foreach (var m in numbersM)
                {
                    if (n == m)
                    {
                        Console.Write($"{n} ");
                    }
                }
            }

        }
    }
}
