using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class TacticalAssistantCoach : AssistantCoach
    {
        /// <summary>
        /// This is a training for the players who have a weakness on the tactical side.
        /// By making players adapt to the coach's system, an increase in their impact estimate occurs.
        /// </summary>
        /// <param name="players"></param>
        public override void TrainPlayers(List<Player> players)
        {
            Random randomNumberGenerator = new Random();
            Console.WriteLine("The players and their improvement on the tactical end after training are listed below:");

            foreach (Player player in players)
            {
                player.ImpactEstimate += player.ImpactEstimate * (randomNumberGenerator.NextDouble() * 0.2);
                Console.WriteLine($"Player name: {player.PlayerName}, Training result: {player.ImpactEstimate}");
            }

            Console.WriteLine();
        }
    }
}
