

using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length==4)
                {
                    IBuyer citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }
            }

            string name;
            while ((name=Console.ReadLine()) !="End")
            {
                buyers.FirstOrDefault(b => b.Name == name)?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b=>b.Food));

        }
    }
}
