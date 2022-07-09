using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DartGame
{
    class DartTournament
    {
        private DartManager dartManager;

        public DartTournament(DartManager dartManager)
        {
            this.dartManager = dartManager;
        }

        public void WelcomeInfo(List<Player> players)
        {
            Console.WriteLine("Welcome to our dart tournament!");
            Console.WriteLine($"There are {players.Count} players in the tournament ready for action!");
            Console.WriteLine();
            Thread.Sleep(2000);

            Dictionary<Player, Player> fixtures;
            fixtures = SetMatchup(players);
            ShowMatchups(fixtures);
            Console.WriteLine();
            Thread.Sleep(2000);

            List<Player> winnersList = dartManager.PlayGames(fixtures);
            DisplayCurrentInfo(winnersList);
        }

        public void DisplayCurrentInfo(List<Player> players)
        {
            if (players.Count != 1)
            {
                Console.WriteLine("Let's move on to the next round!");
                Console.WriteLine($"There are {players.Count} players left!");
                Console.WriteLine("The next matchups are about to set!");
                Console.WriteLine();
                Thread.Sleep(2000);

                Dictionary<Player, Player> fixtures;
                fixtures = SetMatchup(players);
                ShowMatchups(fixtures);
                Console.WriteLine();
                Thread.Sleep(2000);

                List<Player> winnersList = dartManager.PlayGames(fixtures);
                DisplayCurrentInfo(winnersList);
            }
            else
            {
                Console.WriteLine("Here is the winner of the tournament!!!");
                Console.WriteLine($"Congratulations {players[0].Name}!!!");
            }
        }

        // Assumption: The number of players will never be odd.
        private Dictionary<Player, Player> SetMatchup(List<Player> players)
        {
            Random randomIndex = new Random();
            Dictionary<Player, Player> setMatchups = new Dictionary<Player, Player>() { };

            foreach (var player in players)
            {
                bool result = IsInAMatchup(setMatchups, player);

                if (!result)
                {
                Select_Index:
                    int selectedIndex = randomIndex.Next(players.Count);
                    if (player.Name.Equals(players[selectedIndex].Name))
                    {
                        goto Select_Index;
                    }
                    result = IsInAMatchup(setMatchups, players[selectedIndex]);

                    if (!result)
                    {
                        setMatchups.Add(player, players[selectedIndex]);
                    }
                    else
                    {
                        goto Select_Index; // if the selected player has already been matched, the matchmaking must be done again.
                    }
                }
            }

            Console.WriteLine("Matchups are set!");
            return setMatchups;
        }

        private void ShowMatchups(Dictionary<Player, Player> setMatchups)
        {
            int gameNo = 1;
            foreach (var setMatchup in setMatchups)
            {
                Console.WriteLine($"Game {gameNo} between: {setMatchup.Key.Name} vs. {setMatchup.Value.Name}");
                gameNo++;
            }
        }

        private bool IsInAMatchup(Dictionary<Player, Player> matchups, Player player)
        {
            bool isFound = false;

            foreach (var matchup in matchups)
            {
                if (matchup.Key.Name == player.Name || matchup.Value.Name == player.Name)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }
    }
}
