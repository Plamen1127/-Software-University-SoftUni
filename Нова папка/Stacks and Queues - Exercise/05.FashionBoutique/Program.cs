using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacityOfARack = int.Parse(Console.ReadLine());

            int rack = 0;
            int dres = 0;


            while (stack.Count > 0)
            {

                int curentBox = stack.Pop();
                dres += curentBox;

                if (dres > capacityOfARack)
                {
                    dres = 0;
                    rack++;
                    stack.Push(curentBox);
                }
                else if (dres == capacityOfARack)
                {
                    dres = 0;
                    rack++;
                }
            }

            if (dres > 0)
            {
                Console.WriteLine($"{rack + 1}");
            }
            else
            {
                Console.WriteLine(rack);
            }
        }
    }
}
