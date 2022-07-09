using System;
using System.Collections.Generic;

namespace DartGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DartManager dartManager = new DartManager();
            DartTournament dartTournament = new DartTournament(dartManager);

            Dart d1, d2, d3;
            CreateDart(out d1, out d2, out d3);

            Player r1, r2, r3, r4, r5, r6, h1, h2, h3, h4, h5, h6, h7, h8, h9, h10;
            CreateParticipant(d1, d2, d3, out r1, out r2, out r3, out r4, out r5, out r6,
                out h1, out h2, out h3, out h4, out h5, out h6, out h7, out h8, out h9, out h10);

            List<Player> participants = new List<Player> { r1, r2, r3, r4, r5, r6,
                h1, h2, h3, h4, h5, h6, h7, h8, h9, h10 };
            dartTournament.WelcomeInfo(participants);
        }

        private static void CreateParticipant(Dart d1, Dart d2, Dart d3, out Player r1, out Player r2, out Player r3, out Player r4,
            out Player r5, out Player r6, out Player h1, out Player h2, out Player h3, out Player h4, out Player h5,
            out Player h6, out Player h7, out Player h8, out Player h9, out Player h10)
        {
            r1 = new BeginnerRobot() { SelectedDart = d2 };
            r2 = new AverageRobot() { SelectedDart = d3 };
            r3 = new SkilledRobot() { SelectedDart = d1 };
            r4 = new BeginnerRobot() { SelectedDart = d2 };
            r5 = new AverageRobot() { SelectedDart = d3 };
            r6 = new SkilledRobot() { SelectedDart = d1 };

            h1 = new Human() { Name = "Max", SelectedDart = d1 };
            h2 = new Human() { Name = "Chloe", SelectedDart = d2 };
            h3 = new Human() { Name = "Frank", SelectedDart = d3 };
            h4 = new Human() { Name = "Bella", SelectedDart = d1 };
            h5 = new Human() { Name = "Cristopher", SelectedDart = d3 };
            h6 = new Human() { Name = "Dwayne", SelectedDart = d2 };
            h7 = new Human() { Name = "Mary", SelectedDart = d3 };
            h8 = new Human() { Name = "Olivier", SelectedDart = d1 };
            h9 = new Human() { Name = "Olivia", SelectedDart = d2};
            h10 = new Human() { Name = "Sophia", SelectedDart = d1 };
        }

        private static void CreateDart(out Dart d1, out Dart d2, out Dart d3)
        {
            d1 = new TungstenDart() { Name = "Tungsten Dart", Weight = "24 grams" };
            d2 = new BrassDart() { Name = "Brass Dart", Weight = "18 grams" };
            d3 = new WoodenDart() { Name = "Wooden Dart", Weight = "30 grams" };
        }
    }
}
