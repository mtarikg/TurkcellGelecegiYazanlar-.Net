using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    // This tool helps the head coach to find a suitable assistant coach for a player.

    class AssistantCoachFinderTool
    {
        public Coach FindAssistantCoach(Player player, List<AssistantCoach> assistantCoaches)
        {
            AssistantCoach foundAssistantCoach = null;
            foreach (var coach in assistantCoaches)
            {
                if ((player.WeakerSide + "AssistantCoach").Equals(coach.GetType().Name))
                {
                    Console.WriteLine($"Available assistant coach for {player.PlayerName}: {coach.Name}");
                    foundAssistantCoach = coach;
                    break;
                }
            }

            return foundAssistantCoach;
        }
    }
}
