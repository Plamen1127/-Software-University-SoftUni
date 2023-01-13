using System;
using System.Linq;

namespace _1.SumMatrixElements
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
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int colum = 0; colum < colums; colum++)
                {
                    matrix[row, colum] = data[colum];
                    sum += data[colum];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(colums);
            Console.WriteLine(sum);
        }
    }
}
