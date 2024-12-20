// Ignore Spelling: Zusammenarbeits

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Zusammenarbeits_dilemma.Game;

namespace Zusammenarbeits_dilemma
{
    public class Game
    {
        private PlayerPoints Player1 { get; set; }
        private PlayerPoints Player2 { get; set; }

        private int Player1Points { get; set; }
        private int Player2Points { get; set; }
        private bool[,] gameround;

        private int WinWin = 3;
        private int LoseLose = 1;
        private int SuccessfulSteal = 5;
        private int Betrayal = 0;

        public Game(Player player1, Player player2)
        {
            Player1 = new PlayerPoints(player1);
            Player2 = new PlayerPoints(player2);
            Random rnd = new Random();
            gameround = new bool[rnd.Next(100, 200), 2];
        }
        public void RunGame()
        {
            for (int i = 0; i < gameround.GetLength(0); i++)
            {
                GetAnswer(i);
            }
            PrintResults();
            Printaverage();
        }
        private void GetAnswer(int i)
        {
            bool player1Move = i == 0 ? Player1.Player.FirstMove() : Player1.Player.NextMove(gameround[i - 1, 1]);
            bool player2Move = i == 0 ? Player2.Player.FirstMove() : Player2.Player.NextMove(gameround[i - 1, 0]);

            if (player1Move == player2Move)
            {
                int points = player1Move ? WinWin : LoseLose;
                SetPoints(Player1,points);
                SetPoints(Player2,points);
            }
            else
            {
                SetPoints(Player1, (player1Move ? Betrayal : SuccessfulSteal));
                SetPoints(Player2, (player1Move ? SuccessfulSteal : Betrayal));
            }

            gameround[i, 0] = player1Move;
            gameround[i, 1] = player2Move;
        }

        private void SetPoints(PlayerPoints player, int points)
        {
            player.Player.ReceivedPoint(points);
            player.Points += points;
        }
        private void PrintResults()
        {
            
            Console.WriteLine(Player1.Player.Name + ": " + Player1.Points );
            Console.WriteLine(Player2.Player.Name + ": " + Player2.Points );
        }
        private void Printaverage()
        {
            Console.WriteLine(Player1.Player.Name + ": " + (((float)Player1.Points) / gameround.GetLength(0)));
            Console.WriteLine(Player2.Player.Name + ": " + (((float)Player2.Points) / gameround.GetLength(0)));
        }
    }

}