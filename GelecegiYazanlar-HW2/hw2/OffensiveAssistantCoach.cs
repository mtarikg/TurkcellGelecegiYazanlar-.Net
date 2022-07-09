using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class OffensiveAssistantCoach : AssistantCoach
    {
        /// <summary>
        /// This is a training for the players who have a weakness on the offensive side.
        /// After the training, an increase in their offensive rating occurs.
        /// </summary>
        /// <param name="players"></param>
        public override void TrainPlayers(List<Player> players)
        {
            Random randomNumberGenerator = new Random();
            Console.WriteLine("The players and their improvement on the offensive end after training are listed below:");

            foreach (Player player in players)
            {
                player.OffensiveRating += player.OffensiveRating * (randomNumberGenerator.NextDouble() * 0.1);
                Console.WriteLine($"Player name: {player.PlayerName}, Training result: {player.OffensiveRating}");
            }

            Console.WriteLine();
        }
    }
}
