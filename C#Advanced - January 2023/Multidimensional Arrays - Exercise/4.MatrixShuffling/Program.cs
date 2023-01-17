using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();


                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "swap" && command.Length == 5
                    && int.Parse(command[1]) >= 0 && int.Parse(command[1]) < size[0]
                    && int.Parse(command[2]) >= 0 && int.Parse(command[2]) < size[1]
                    && int.Parse(command[3]) >= 0 && int.Parse(command[3]) < size[0]
                    && int.Parse(command[4]) >= 0 && int.Parse(command[4]) < size[1])
                    
                {
                    string saveCurentChange = matrix[int.Parse(command[1]), int.Parse(command[2])];
                    matrix[int.Parse(command[1]), int.Parse(command[2])] = matrix[int.Parse(command[3]), int.Parse(command[4])];
                    matrix[int.Parse(command[3]), int.Parse(command[4])] = saveCurentChange;

                    for (int row = 0; row < size[0]; row++)
                    {
                        for (int col = 0; col < size[1]; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }


        }
    }
}
