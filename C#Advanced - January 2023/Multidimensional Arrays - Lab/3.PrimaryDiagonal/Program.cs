using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int columns = size;

            int[,] matrix = new int[rows, columns];
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, row];
            }

            Console.WriteLine(sum);

        }
    }
}
