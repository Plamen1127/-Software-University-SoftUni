using System;
using System.Collections.Generic;
using System.Linq;

namespace primerna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Dictionary<string, int> swords = new Dictionary<string, int>
{
    { "Gladius",0},
    { "Shamshir",0},
    { "Katana",0},
    { "Sabre",0},
    { "Broadsword",0},
};

            Queue<int> queueSteel = new Queue<int>(steel);
            Stack<int> stackCarbon = new Stack<int>(carbon);

            int counterSwords = 0;

            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                int firststeel = queueSteel.Dequeue();
                int curentCarbon = stackCarbon.Pop();
                int sum = firststeel + curentCarbon;
                bool makeSword = true;

                if (sum == 70)
                {
                    swords["Gladius"]++;
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                }
                else if (sum == 90)
                {
                    swords["Sabre"]++;
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                }
                else
                {
                    curentCarbon += 5;
                    stackCarbon.Push(curentCarbon);
                    makeSword = false;
                }
                if (makeSword)
                {
                    counterSwords++;
                }


            }

            if (counterSwords > 0)
            {
                Console.WriteLine($"You have forged {counterSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (queueSteel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", queueSteel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (stackCarbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", stackCarbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swords.OrderBy(s => s.Key))
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }

            }
        }
    }
}
