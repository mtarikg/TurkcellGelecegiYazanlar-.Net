using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    // Beginner Robot is considered if its skill level is 1 or 2.
    class BeginnerRobot : Robot
    {
        public BeginnerRobot()
        {
            SkillLevel = new Random().Next(1, 3);
        }
    }
}
