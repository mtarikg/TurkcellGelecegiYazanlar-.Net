using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    // This tool measures whether a player is strong enough on several parts of the basketball game.

    class PlayerStatAnalyzerTool
    {
        public bool CheckSufficientOffensiveRating(Player player)
        {
            bool isSufficient = false;
            if (player.OffensiveRating >= 110.0)
            {
                isSufficient = true;
            }

            return isSufficient;
        }

        public bool CheckSufficientDefensiveRating(Player player)
        {
            bool isSufficient = false;
            if (player.DefensiveRating >= 108.0)
            {
                isSufficient = true;
            }

            return isSufficient;
        }

        public bool CheckSufficientImpactEstimate(Player player)
        {
            bool isSufficient = false;
            if (player.ImpactEstimate >= 10.0)
            {
                isSufficient = true;
            }

            return isSufficient;
        }

        public void ShowResult(Player player)
        {
            bool resultOnOffense = CheckSufficientOffensiveRating(player);
            bool resultOnDefense = CheckSufficientDefensiveRating(player);
            bool resultOnTactics = CheckSufficientImpactEstimate(player);

            if (!resultOnOffense)
            {
                Console.WriteLine($"{player.PlayerName} needs to train on the offensive side of his game.");
                player.WeakerSide = "Offensive";
                return;
            }

            if (!resultOnDefense)
            {
                Console.WriteLine($"{player.PlayerName} needs to train on the defensive side of his game.");
                player.WeakerSide = "Defensive";
                return;
            }
           
            if (!resultOnTactics)
            {
                Console.WriteLine($"{player.PlayerName} needs to train on the tactical side of his game.");
                player.WeakerSide = "Tactical";
                return;
            }
        }
    }
}
