public class ShipPlacer
{
    private Grid grid;
    private List<int[,]> shipShapes;

    public ShipPlacer(Grid grid, List<int[,]> shipShapes)
    {
        this.grid = grid;
        this.shipShapes = shipShapes;
    }

    public void PlaceShips()
    {
        Random rand = new Random();
        for (int i = 0; i < shipShapes.Count; i++)
        {
            bool placed = false;
            while (!placed)
            {
                int row = rand.Next(grid.GetGridSize());
                int col = rand.Next(grid.GetGridSize());
                bool horizontal = rand.Next(2) == 0;

                if (CanPlaceShip(shipShapes[i], row, col, horizontal))
                {
                    PlaceShip(shipShapes[i], row, col, horizontal);
                    placed = true;
                }
            }
        }
    }

    private bool CanPlaceShip(int[,] shape, int row, int col, bool horizontal)
    {
        int kRows = shape.GetLength(0);
        int kCols = shape.GetLength(1);

        for (int i = 0; i < kRows; i++)
        {
            for (int j = 0; j < kCols; j++)
            {
                if (shape[i, j] == 1)
                {
                    int r = row + (horizontal ? 0 : i);
                    int c = col + (horizontal ? j : 0);

                    if (r >= grid.GetGridSize() || c >= grid.GetGridSize() || grid.GetCell(r, c) != '.')
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private void PlaceShip(int[,] shape, int row, int col, bool horizontal)
    {
        int kRows = shape.GetLength(0);
        int kCols = shape.GetLength(1);

        for (int i = 0; i < kRows; i++)
        {
            for (int j = 0; j < kCols; j++)
            {
                if (shape[i, j] == 1)
                {
                    int r = row + (horizontal ? 0 : i);
                    int c = col + (horizontal ? j : 0);

                    grid.UpdateCell(r, c, 'S');
                    grid.PlaceShipInGrid(r, c);
                }
            }
        }
    }
}