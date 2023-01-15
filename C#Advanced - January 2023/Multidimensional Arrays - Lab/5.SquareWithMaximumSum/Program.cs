using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
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
            int columns = size[1];

            int[,] matrix = new int[rows, columns];
            int maxSum = 0;
            int row1 = 0;
            int row2 = 0;
            int col1 = 0;
            int col2 = 0;


            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {

                    int curentSum = 0;
                    curentSum = matrix[row + 1, col + 1] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row, col];

                    if (curentSum > maxSum)
                    {
                        maxSum = curentSum;
                        row1 = matrix[row, col];
                        row2 = matrix[row, col + 1];
                        col1 = matrix[row + 1, col];
                        col2 = matrix[row + 1, col + 1];
                    }
                }

            }

            Console.WriteLine($"{row1} {row2}");
            Console.WriteLine($"{col1} {col2}");
            Console.WriteLine(maxSum);
        }
    }
}
