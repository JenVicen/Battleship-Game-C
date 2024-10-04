public class Grid
{
    private int gridSize;
    private char[,] grid;
    private bool[,] shipGrid; // Grid to track ships

    public Grid(int size)
    {
        gridSize = size;
        grid = new char[gridSize, gridSize];
        shipGrid = new bool[gridSize, gridSize]; // Initialize shipGrid
    }

    public void InitializeGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = '.';
            }
        }
    }

    public void PrintGrid(bool revealShips)
    {
        Console.Write("  ");
        for (int i = 0; i < gridSize; i++)
        {
            Console.Write((char)('A' + i) + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < gridSize; i++)
        {
            Console.Write((i + 1).ToString().PadLeft(2) + " ");
            for (int j = 0; j < gridSize; j++)
            {
                // Show ships if revealShips is true, else show '.'
                char displayChar = grid[i, j] == 'S' && !revealShips ? '.' : grid[i, j];
                Console.Write(displayChar + " ");
            }
            Console.WriteLine();
        }
    }

    public void UpdateCell(int row, int col, char value)
    {
        grid[row, col] = value;
    }

    public char GetCell(int row, int col)
    {
        return grid[row, col];
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void PlaceShipInGrid(int row, int col)
    {
        shipGrid[row, col] = true;
        UpdateCell(row, col, 'S'); // Ensure ship is marked on OwnGrid
    }

    public bool IsShipAt(int row, int col)
    {
        return shipGrid[row, col];
    }

    public bool HasAllShipsSunk()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (shipGrid[i, j] && grid[i, j] != 'J' && grid[i, j] != 'A') // Check for hits only
                {
                    return false;
                }
            }
        }
        return true;
    }
}