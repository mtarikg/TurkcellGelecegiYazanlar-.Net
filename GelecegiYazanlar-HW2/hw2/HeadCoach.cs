using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    /* The responsbility of a head coach is the following:
    /* Assigning each player to a specific assistant coach by analyzing the results of different metrics.
    /* The necessary tasks are handled by a tool; the coach will only deal with the results which meets the Single Responsibility Principle. */

    class HeadCoach : Coach
    {
        private PlayerStatAnalyzerTool statAnalyzerTool;
        private AssistantCoachFinderTool coachFinderTool;
        public List<AssistantCoach> AssistantCoaches { get; set; }

        public HeadCoach(PlayerStatAnalyzerTool statAnalyzerTool, AssistantCoachFinderTool coachFinderTool)
        {
            this.statAnalyzerTool = statAnalyzerTool;
            this.coachFinderTool = coachFinderTool;
        }

        /// <summary>
        /// This method will assign each player to only one of the assistant coaches.
        /// </summary>
        /// <param name="players"></param>
        public void AssignPlayerToAssistantCoach(List<Player> players)
        {
            foreach (Player player in players)
            {
                statAnalyzerTool.ShowResult(player);

                AssistantCoach selectedAssistantCoach;
                selectedAssistantCoach = (AssistantCoach)coachFinderTool.FindAssistantCoach(player, AssistantCoaches);

                selectedAssistantCoach.PlayersList.Add(player);
                Console.WriteLine($"{player.PlayerName} has been assigned to {selectedAssistantCoach.Name}!");
                Console.WriteLine();
            }
        }
    }
}
