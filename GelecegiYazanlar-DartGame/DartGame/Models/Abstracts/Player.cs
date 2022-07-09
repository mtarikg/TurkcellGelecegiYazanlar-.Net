using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    abstract class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Dart SelectedDart { get; set; }

        /// <summary>
        /// First, the area the dart hits is calculated, then its corresponding value is fetched.
        /// Returns the score of the player for each round.
        /// </summary>
        /// <param name="dart"></param>
        /// <returns></returns>
        public virtual int ThrowDart(Dart dart)
        {
            Random randomArea = new Random();
            double firstIndex = randomArea.Next(0, ((DartTable.AreasToHit.Count - 1) * 100 + 1)) / 100;

            // The type of the dart a player has shows its effect here.
            int areaIndex = (int)Math.Round(firstIndex + dart.Impact);
            if (areaIndex >= DartTable.AreasToHit.Count)
            {
                areaIndex = DartTable.AreasToHit.Count - 1;
            }

            Random randomPoint = new Random();
            int pointIndex = randomPoint.Next(DartTable.AreasToHit[areaIndex].Count);

            int roundScore = Convert.ToInt32(DartTable.AreasToHit[areaIndex][pointIndex].ToString());
            return roundScore;
        }
    }
}
