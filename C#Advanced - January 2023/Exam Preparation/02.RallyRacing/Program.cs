

int size = int.Parse(Console.ReadLine());

string carNumber = Console.ReadLine();

string[,] matrix = new string[size, size];

int distance = 0;

int firstTunnelRow = 0;
int firstTunnelCol = 0;
int secundTunnelRow = 0;
int secundTunnelCol = 0;
bool isFirstTunelFound = false;

for (int row = 0; row < size; row++)
{
    string[] rowData = Console.ReadLine().Split(" ");

    for (int col = 0; col < size; col++)
	{
		
		matrix[row, col] = rowData[col];
		if (rowData[col]=="T" && !isFirstTunelFound)
		{
			firstTunnelRow = row;
			firstTunnelCol = col;
			isFirstTunelFound = true;
		}
		else if(rowData[col] == "T" && isFirstTunelFound)
		{
			secundTunnelRow = row;
			secundTunnelCol = col;
		}
	}
}

string command = Console.ReadLine();
int carRow = 0;
int carCol = 0;
bool isFinishCar = false;

while (command!= "End")
{
	if (command=="left")
	{
		carCol--;
		
	}
	else if (command=="right")
	{
		carCol++;
        
    }
    else if (command == "up")
    {
        carRow--;
       
    }
    else if (command == "down")
    {
        carRow++;
       
    }

	if (matrix[carRow, carCol] == ".")
	{
		distance += 10;
	}
	if (matrix[carRow, carCol] == "T")
	{
		matrix[carRow, carCol] = ".";
        if (carRow == firstTunnelRow && carCol == firstTunnelCol)
        {
            carRow = secundTunnelRow;
            carCol = secundTunnelCol;
        }
		else
		{
			carRow = firstTunnelRow;
			carCol = firstTunnelCol;
		}
        matrix[carRow, carCol] = ".";
		distance += 30;

    }

	if (matrix[carRow,carCol]=="F")
	{
	
		distance += 10;
		isFinishCar = true;
		break;

    }

    command = Console.ReadLine();
}
matrix[carRow, carCol] = "C";


if (isFinishCar)
{
	Console.WriteLine($"Racing car {carNumber} finished the stage!");
}
else
{
	Console.WriteLine($"Racing car {carNumber} DNF.");
}

Console.WriteLine($"Distance covered {distance} km.");
PrintMatrix(matrix);

static void PrintMatrix<T>(T[,] matrix)
{
	for (int row = 0; row < matrix.GetLength(0); row++)
	{
		for (int col = 0; col < matrix.GetLength(1); col++)
		{
			Console.Write(matrix[row, col]);
		}
		Console.WriteLine(); ;
	}
}