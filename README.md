# Battleship-Game-C#

Battleship game developed in C# as a first homework for the Object-Oriented Programming class.

By Jennifer Vicentes

## Table of Contents

- [Introduction](#introduction)
- [Gameplay](#gameplay)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Code Structure](#code-structure)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## Introduction

Battleship is a classic two-player game where players strategically place ships on a grid and take turns guessing the locations of each other's ships. This implementation allows players to enjoy a digital version of the game with a simple command-line interface. The objective is to sink all the opponent's ships before they sink yours.

## Gameplay

1. **Setting Up the Game:**
- Two players take turns. The first player is labeled "Player 1" and the second "Player 2".
- Each player will place their ships on their respective boards before the game starts.

2. **Taking Turns:**
- During a player's turn, they will enter coordinates (e.g., A1, B3) to target a location on the opponent's board.
- If the shot hits an opponent's ship, it is marked with an 'X'; if it misses, it is marked with an 'O'.
- After each turn, both players can see their own board and the opponent's attack board.

3. **Winning the Game:**
- The game continues until one player successfully sinks all of the opponent's ships.
- When a player sinks all of the opponent's ships, a message is displayed indicating that they have won the game.


## Features

- **Two-player gameplay:** Play against another human player.
- **Dynamic ship placement:** Ships are randomly placed on the board.
- **Turn-based system:** Players take turns shooting at the opponent's ships.
- **Hit and Miss tracking:** Players can see their shots and the results on their attack board.
- **Victory detection:** The game announces the winner once all opponent ships are sunk.

## Installation

To run this Battleship game, you will need:

- .NET SDK (version 6.0 or later)

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/JenVicen/Battleship-Game-HW3
   ```

2. **Navigate to the Project Directory**:
   ```bash
   cd battleship-game-hw3
   ```

3. **Open the Project in Visual Studio or your preferred C# IDE**.

4. **Restore dependencies (if using additional libraries):**
    ```bash
   dotnet restore
   ```

5. **Build the project:**
    ```bash
   dotnet build
   ```

## Usage

1. Open a terminal and navigate to the project directory.
2. Run the game using:
    ```bash
   dotnet run
   ```

### Input Format

- The coordinates must be in the format:
  - Column: A-E
  - Row: 1-5
- Example: "A1" represents the top-left corner of the grid.

## Code Structure

- **BattleshipGame:** The entry point of the application, managing game flow and player interactions.
    - **BasePlayer:** An abstract class that defines common properties and methods for all players.
    - **Player:** Inherits from BasePlayer and implements ship placement logic.
    - **Grid:** Manages the game board, including ship placement and hit/miss tracking.
    - **ShipPlacer:** Handles the placement of ships on the player's grid.
    - **GameLogic:** Contains the core game logic, including turn handling and victory detection.

## License

N/A

## Acknowledgments

- Inspired by the classic game Battleship and a previous tic tac toe game developed in C for the Programming Principles class.