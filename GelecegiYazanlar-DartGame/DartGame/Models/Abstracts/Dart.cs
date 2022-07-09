using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    abstract class Dart
    {
        private static int dartIDCounter = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public double Impact { get; set; } // Impact means extra accuracy depending on the type.

        public Dart()
        {
            ID = dartIDCounter++;
        }
    }
}
