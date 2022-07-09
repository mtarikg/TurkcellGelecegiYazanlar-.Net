using System;
using System.Collections.Generic;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerStatAnalyzerTool playerStatAnalyzerTool = new PlayerStatAnalyzerTool();
            AssistantCoachFinderTool assistantCoachFinderTool = new AssistantCoachFinderTool();

            Player p1 = CreatePlayer(1, "Nikola Jokic", 117.3, 106.5, 23.5);
            Player p2 = CreatePlayer(2, "Aaron Gordon", 117.0, 109.4, 9.6);
            Player p3 = CreatePlayer(3, "Will Barton", 109.8, 109.1, 10.3);

            AssistantCoach assistantCoach1, assistantCoach2, assistantCoach3;
            CreateAssistantCoach(out assistantCoach1, out assistantCoach2, out assistantCoach3);
            HeadCoach headCoach = CreateHeadCoach(playerStatAnalyzerTool, assistantCoachFinderTool,
                assistantCoach1, assistantCoach2, assistantCoach3, p1, p2, p3);

            headCoach.AssignPlayerToAssistantCoach(headCoach.PlayersList);

            assistantCoach1.TrainPlayers(assistantCoach1.PlayersList);
            assistantCoach2.TrainPlayers(assistantCoach2.PlayersList);
            assistantCoach3.TrainPlayers(assistantCoach3.PlayersList);
        }

        private static Player CreatePlayer(int id, string name, double oRating, double dRating, double iEstimate)
        {
            return new Player
            {
                PlayerID = id,
                PlayerName = name,
                OffensiveRating = oRating,
                DefensiveRating = dRating,
                ImpactEstimate = iEstimate
            };
        }

        private static void CreateAssistantCoach(out AssistantCoach assistantCoach1, out AssistantCoach assistantCoach2, out AssistantCoach assistantCoach3)
        {
            assistantCoach1 = new OffensiveAssistantCoach()
            {
                CoachID = 1,
                Name = "David Adelman",
                PlayersList = new List<Player> { },
            };
            assistantCoach2 = new DefensiveAssistantCoach()
            {
                CoachID = 2,
                Name = "Jordi Fernandez",
                PlayersList = new List<Player> { },
            };
            assistantCoach3 = new TacticalAssistantCoach()
            {
                CoachID = 3,
                Name = "Popeye Jones",
                PlayersList = new List<Player> { },
            };
        }

        private static HeadCoach CreateHeadCoach(PlayerStatAnalyzerTool playerStatAnalyzerTool, AssistantCoachFinderTool assistantCoachFinderTool, AssistantCoach assistantCoach1, AssistantCoach assistantCoach2, AssistantCoach assistantCoach3, Player p1, Player p2, Player p3)
        {
            return new HeadCoach(playerStatAnalyzerTool, assistantCoachFinderTool)
            {
                CoachID = 1,
                Name = "Michael Malone",
                AssistantCoaches = new List<AssistantCoach> { assistantCoach1, assistantCoach2, assistantCoach3 },
                PlayersList = new List<Player> { p1, p2, p3 }
            };
        }
    }
}
