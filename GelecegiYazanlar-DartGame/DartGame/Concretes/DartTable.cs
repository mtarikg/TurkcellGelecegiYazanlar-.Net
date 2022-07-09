using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DartGame
{
    class DartTable
    {
        public static List<int> SingleScores = new List<int>() { 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5 };
        public static List<int> DoubleScores = new List<int>(SingleScores.Select(score => score *= 2));
        public static List<int> TripleScores = new List<int>(SingleScores.Select(score => score *= 3));
        public static List<int> BullseyeScores = new List<int>() { 25, 50 };

        public static List<List<int>> AreasToHit = new List<List<int>>() { SingleScores, DoubleScores, TripleScores, BullseyeScores };
    }
}
