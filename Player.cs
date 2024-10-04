public class Player : BasePlayer
{
    private ShipPlacer shipPlacer;

    public Player(string name) : base(name) { }

    public override void PlaceShips()
    {
        var shipShapes = new List<int[,]>
        {
            new int[,] { { 1, 1, 1, 1, 1 } }, // Carrier (5 cells)
            new int[,] { { 1, 1, 1, 1 } },    // Battleship (4 cells)
            new int[,] { { 1, 1, 1 } },       // Submarine (3 cells)
            new int[,] { { 1, 1, 1 } },       // Destroyer (3 cells)
            new int[,] { { 1, 1 } }           // Patrol boat (2 cells)
        };

        shipPlacer = new ShipPlacer(OwnGrid, shipShapes);
        shipPlacer.PlaceShips();
    }
}