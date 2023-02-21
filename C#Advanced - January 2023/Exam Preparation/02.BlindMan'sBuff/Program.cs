int[] dataSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int sizeRow = dataSize[0];
int sizeCol = dataSize[1];

string[,] matrix = new string[sizeRow, sizeCol];
int curentRow = 0;
int curenCol = 0;

for (int row = 0; row < sizeRow; row++)
{
    string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < sizeCol; col++)
    {
        matrix[row, col] = data[col];

        if (matrix[row, col] == "B")
        {
            curentRow = row;
            curenCol = col;
        }
    }
}
string command = Console.ReadLine();
int countPozishan = 0;
int taching = 0;

while (command != "Finish")
{
    if (taching == 3)
    {
        break;
       
    }
    if (command == "up")
    {
        curentRow--;
        countPozishan++;
        if (curentRow < 0 || matrix[curentRow, curenCol] == "O")
        {
            curentRow++;
            countPozishan--;
        }
        else if (matrix[curentRow, curenCol] == "P")
        {
            matrix[curentRow, curenCol] = "-";
            taching++;

        }

    }
    else if (command == "down")
    {
        curentRow++;
        countPozishan++;
        if (curentRow > sizeRow - 1 || matrix[curentRow, curenCol] == "O")
        {
            curentRow--;
            countPozishan--;

        }
        else if (matrix[curentRow, curenCol] == "P")
        {
            matrix[curentRow, curenCol] = "-";
            taching++;

        }

    }
    else if (command == "right")
    {
        curenCol++;
        countPozishan++;
        if (curenCol > sizeCol - 1 || matrix[curentRow, curenCol] == "O")
        {
            curenCol--;
            countPozishan--;
        }
        else if (matrix[curentRow, curenCol] == "P")
        {
            matrix[curentRow, curenCol] = "-";
            taching++;

        }


    }
    else if (command == "left")
    {

        curenCol--;
        countPozishan++;
        if (curenCol < 0 || matrix[curentRow, curenCol] == "O")
        {
            curenCol++;
            countPozishan--;
        }
        else if (matrix[curentRow, curenCol] == "P")
        {
            matrix[curentRow, curenCol] = "-";
            taching++;

        }
    }

    command = Console.ReadLine();
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {taching} Moves made: {countPozishan}");




static void PrintMatrix<T>(T[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }

        Console.WriteLine();
    }
}

