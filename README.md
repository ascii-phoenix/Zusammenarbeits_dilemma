# Zusammenarbeits Dilemma

**Zusammenarbeits Dilemma** is a simulation of the well-known **Prisoner's Dilemma** game, where two players interact over a series of rounds, making decisions based on their own strategies and their opponent's actions. The game is implemented in C# and demonstrates different strategies for cooperation and betrayal, with scoring based on mutual cooperation, mutual betrayal, or one player betraying while the other cooperates.

## Features

- **Player Strategies**: The game allows for different player strategies, including the ability for players to cooperate or betray based on the previous moves of their opponent.
- **Randomized Rounds**: The number of rounds in each game is randomly selected, with a minimum of 100 rounds and a maximum of 200 rounds.
- **Scoring System**: Points are awarded based on the following:
  - **Win-Win** (both cooperate): 3 points each
  - **Lose-Lose** (both betray): 1 point each
  - **Successful Steal** (one betrays, the other cooperates): 5 points for the betrayer, 0 points for the cooperator
  - **Betrayal**: 0 points for the betrayer, 5 points for the cooperator

## How It Works

- The **Game** class initializes two players with their respective strategies and tracks the results of each round.
- In each round, both players choose to cooperate or betray based on their strategy and the history of the game.
- The game evaluates the outcomes of each round, updates the scores, and prints the final results and average points per round.

## Example Output
```bash
Player1: 350
Player2: 420
Player1: 3.5
Player2: 4.2
## Player Interface
```
The game utilizes the following `Player` interface to define the required methods and properties for any player participating in the game:

```csharp
public interface Player
{
    public string Name { get; set; }
    public bool FirstMove();
    public bool NextMove(bool previousMove);
    public void ReceivedPoint(int ReceivedPointFromRound);
}
```
