using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = new int[data.Length];
                int columns = jagged[row].Length;

                for (int col = 0; col < columns; col++)
                {
                    jagged[row][col] = data[col];
                }
            }

            string input = Console.ReadLine();


            while (input != "END")
            {
                string[] array = input.Split(" ").ToArray();
                string command = array[0];
                int row = int.Parse(array[1]);
                int col = int.Parse(array[2]);
                int value = int.Parse(array[3]);

                if (row < 0 || row > jagged.Length || col < 0 || col > jagged.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");

                }
                Console.WriteLine();
            }
        }
    }
}
