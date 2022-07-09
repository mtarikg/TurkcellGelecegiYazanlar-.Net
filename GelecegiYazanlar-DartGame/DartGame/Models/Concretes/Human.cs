using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    class Human : Player
    {
        private static int humanIDCounter = 1;

        public Human()
        {
            base.ID = humanIDCounter++;
        }
    }
}
