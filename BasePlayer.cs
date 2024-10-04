public abstract class BasePlayer
{
    public string Name { get; private set; }
    public Grid OwnGrid { get; private set; }
    public Grid AttackGrid { get; private set; }
    private HashSet<string> previousShots; // Store previous shots

    protected BasePlayer(string name)
    {
        Name = name;
        previousShots = new HashSet<string>();
    }

    public void InitializeGrid(int gridSize)
    {
        OwnGrid = new Grid(gridSize);
        AttackGrid = new Grid(gridSize);
        OwnGrid.InitializeGrid();
        AttackGrid.InitializeGrid();
    }

    public bool AddShot(string shot)
    {
        return previousShots.Add(shot); // Add shot and return success
    }

    public bool HasShotBefore(string shot)
    {
        return previousShots.Contains(shot); // Check if shot was used
    }

    public abstract void PlaceShips();
}
