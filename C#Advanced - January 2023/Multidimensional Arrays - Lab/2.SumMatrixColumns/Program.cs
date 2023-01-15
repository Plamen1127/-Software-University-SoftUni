using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int colums = size[1];

            int[,] matrix = new int[rows, colums];

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < colums; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int col = 0; col < colums; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write($"{matrix[row, col]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
