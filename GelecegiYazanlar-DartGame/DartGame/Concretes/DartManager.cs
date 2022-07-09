using System;
using System.Collections.Generic;
using System.Threading;

namespace DartGame
{
    class DartManager
    {
        /// <summary>
        /// Each game is played one after another, returning a list of winners for each round in the end.
        /// </summary>
        /// <param name="games"> Each key-value pair represents a matchup. </param>
        /// <returns></returns>
        public List<Player> PlayGames(Dictionary<Player, Player> games)
        {
            int targetedPoints = 150;
            List<Player> winners = new List<Player>() { };

            foreach (var game in games)
            {
                int firstPlayerScore = 0;
                int secondPlayerScore = 0;
                bool firstPlayerTurn = true;

                Console.WriteLine($"{game.Key.Name} vs. {game.Value.Name}");

                while (!IsGameEnded(targetedPoints, firstPlayerScore, secondPlayerScore))
                {
                    if (firstPlayerTurn)
                    {
                        Console.WriteLine($"It's {game.Key.Name}'s turn!");
                        int roundScore = game.Key.ThrowDart(game.Key.SelectedDart);
                        firstPlayerScore += roundScore;
                        firstPlayerTurn = false;
                    }
                    else
                    {
                        Console.WriteLine($"It's {game.Value.Name}'s turn!");
                        int roundScore = game.Value.ThrowDart(game.Value.SelectedDart);
                        secondPlayerScore += roundScore;
                        firstPlayerTurn = true;
                    }

                    ShowCurrentInfo(game.Key.Name, firstPlayerScore, game.Value.Name, secondPlayerScore);
                }

                ShowWinner(targetedPoints, winners, game, firstPlayerScore);
            }

            return winners;
        }

        private void ShowWinner(int targetedPoints, List<Player> winners, KeyValuePair<Player, Player> game, int firstPlayerScore)
        {
            if (firstPlayerScore >= targetedPoints)
            {
                Console.WriteLine($"{game.Key.Name} is the winner of this game!");
                Console.WriteLine();
                winners.Add(game.Key);
                Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine($"{game.Value.Name} is the winner of this game!");
                Console.WriteLine();
                winners.Add(game.Value);
                Thread.Sleep(2500);
            }
        }

        /// <summary>
        /// Shows the current state of the game after each turn.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="firstPlayerScore"></param>
        /// <param name="player2"></param>
        /// <param name="secondPlayerScore"></param>
        private void ShowCurrentInfo(string player1, int firstPlayerScore, string player2, int secondPlayerScore)
        {
            Console.WriteLine("Total points after this round:");
            Console.WriteLine($"{player1}:{firstPlayerScore} && {player2}:{secondPlayerScore}");
            Console.WriteLine();
            Thread.Sleep(2500);
        }

        /// <summary>
        /// Checks whether one player has got the specified points.
        /// </summary>
        /// <param name="targetedPoints"></param>
        /// <param name="firstPlayerScore"></param>
        /// <param name="secondPlayerScore"></param>
        /// <returns></returns>
        private bool IsGameEnded(int targetedPoints, int firstPlayerScore, int secondPlayerScore)
        {
            bool result = true;
            if (firstPlayerScore < targetedPoints && secondPlayerScore < targetedPoints)
            {
                result = false;
            }

            return result;
        }
    }
}
