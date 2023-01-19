using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < times; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<decimal>());

                }

                studentsGrades[name].Add(grade);
            }

            foreach (var item in studentsGrades)
            {
                Console.Write($"{item.Key} -> ");

                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
