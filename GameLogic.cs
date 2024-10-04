public class GameLogic
{
    private Player player1;
    private Player player2;

    public GameLogic(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public bool IsGameOver()
    {
        return player1.OwnGrid.HasAllShipsSunk() || player2.OwnGrid.HasAllShipsSunk();
    }

    public Player GetWinner()
    {
        if (player1.OwnGrid.HasAllShipsSunk())
        {
            return player2;
        }
        return player1;
    }

    public void PlayTurn(Player currentPlayer, Player opponent)
    {
        // Print turn label
        Console.WriteLine($"--- {currentPlayer.Name} Turn ---");
        Console.WriteLine("YOUR BOARD:");
        currentPlayer.OwnGrid.PrintGrid(true); // Show own grid with ships
        Console.WriteLine("ENEMY'S BOARD:");
        currentPlayer.AttackGrid.PrintGrid(false); // Show opponent's attack grid

        string input;
        do
        {
            input = GetUserInput();
        } while (!ProcessTurn(currentPlayer, opponent, input));

        // Check for victory after the turn
        if (opponent.OwnGrid.HasAllShipsSunk())
        {
            Console.WriteLine($"{currentPlayer.Name} has sunk all of {opponent.Name}'s ships. ¡{currentPlayer.Name} wins!");
        }
    }

    private bool ProcessTurn(Player currentPlayer, Player opponent, string input)
    {
        if (!currentPlayer.HasShotBefore(input))
        {
            currentPlayer.AddShot(input); // Store the shot if it's valid
            int row = input[1] - '1'; // Convert to zero-based index
            int col = input[0] - 'A'; // Convert to zero-based index

            if (opponent.OwnGrid.GetCell(row, col) == 'S')
            {
                currentPlayer.AttackGrid.UpdateCell(row, col, 'X'); // Player hit
                opponent.OwnGrid.UpdateCell(row, col, 'H'); // Mark hit on opponent's grid
                Console.WriteLine("Hit!");
            }
            else
            {
                currentPlayer.AttackGrid.UpdateCell(row, col, 'O'); // Player miss
                opponent.OwnGrid.UpdateCell(row, col, 'M'); // Mark miss on opponent's grid
                Console.WriteLine("Miss!");
            }
            return true;
        }
        else
        {
            Console.WriteLine("You have already shot at that cell. Please choose another one!");
        }
        return false;
    }

    private static string GetUserInput()
    {
        Console.Write("Enter coordinates (e.g., A1): ");
        return Console.ReadLine().ToUpper();
    }
}
