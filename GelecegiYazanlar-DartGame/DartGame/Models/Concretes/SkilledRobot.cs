using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    // Skilled Robot is considered if its skill level is 4 or 5.
    class SkilledRobot : Robot
    {
        public SkilledRobot()
        {
            SkillLevel = new Random().Next(4, 6);
        }
    }
}
