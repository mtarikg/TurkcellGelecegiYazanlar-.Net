using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    abstract class Robot : Player, IAim
    {
        private static int robotIDCounter = 1;
        public int SkillLevel { get; set; }

        public Robot()
        {
            base.ID = robotIDCounter++;
            Name = $"Robot{ID}";
        }

        // The ability to aim is added to robots via the interface.
        public void Aim(Dart dart)
        {
            Console.WriteLine($"{Name} with the skill level of {SkillLevel} is aiming the dart!");
            dart.Impact += SkillLevel * 0.1;
        }

        public override int ThrowDart(Dart dart)
        {
            int roundScore;

            Aim(dart);
            roundScore = base.ThrowDart(dart);

            return roundScore;
        }
    }
}
