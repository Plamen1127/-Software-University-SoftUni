using System;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int columns = size;

            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            char simbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if(matrix[row, col] == simbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }

                }
            }
            Console.WriteLine($"{simbol} does not occur in the matrix");




        }
    }
}
