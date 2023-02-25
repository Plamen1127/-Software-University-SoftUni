using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();
            table.Add("salad", 350);
            table.Add("soup", 490);
            table.Add("pasta", 680);
            table.Add("steak", 790);

            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int mealsCount = 0;
            int leftover = 0;
            bool next = true;
            while (meals.Count > 0 && calories.Count > 0)
            {
                string meal = meals.Peek();
                int currCal = calories.Peek();
                int currMealCal = 0;

                if (next)
                {
                    currMealCal = table[meal];
                }
                else
                {
                    currMealCal = leftover;
                }


                if (currCal > currMealCal)
                {
                    meals.Dequeue();
                    calories.Pop();
                    currCal -= currMealCal;
                    calories.Push(currCal);
                    mealsCount++;
                    next = true;
                }
                else
                {
                    calories.Pop();
                    currMealCal -= currCal;
                    leftover = currMealCal;
                    next = false;

                    if (calories.Count == 0)
                    {
                        meals.Dequeue();
                        mealsCount++;
                    }

                }

            }

            if (meals.Count <= 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else if (calories.Count <= 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

        }
    }
}
