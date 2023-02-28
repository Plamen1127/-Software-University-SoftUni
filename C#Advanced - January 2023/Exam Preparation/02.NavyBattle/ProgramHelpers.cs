using System;

internal static class ProgramHelpers
{





    public static void PrintMatrix<T>(T[,] matrix, Action<T> printer)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                printer(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}