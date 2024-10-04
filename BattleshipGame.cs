public static class BattleshipGame
{
    private static Player player1;
    private static Player player2;
    private static GameLogic gameLogic;

    public static void Main()
    {
        PlayGame();
    }

    public static void PlayGame()
    {
        Console.WriteLine("Welcome to Battleship!");

        // Setup players
        player1 = new Player("Player 1");
        player2 = new Player("Player 2");

        // Initialize grids
        int gridSize = 5;
        player1.InitializeGrid(gridSize);
        player2.InitializeGrid(gridSize);

        // Place ships
        player1.PlaceShips();
        player2.PlaceShips();

        // Create game logic
        gameLogic = new GameLogic(player1, player2);

        // Start the game loop
        while (!gameLogic.IsGameOver())
        {
            gameLogic.PlayTurn(player1, player2);
            if (gameLogic.IsGameOver()) break;
            gameLogic.PlayTurn(player2, player1);
        }

        // Print final result
        Player winner = gameLogic.GetWinner();
        Console.WriteLine($"Game Over! {winner.Name} wins!");
    }
}