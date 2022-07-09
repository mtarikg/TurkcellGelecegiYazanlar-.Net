using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    // Wooden Dart has an impact in the range of 0.10% to 0.17% to hit a better area when being thrown.
    class WoodenDart : Dart
    {
        public WoodenDart()
        {
            Impact = new Random().Next(10, 18) * 0.01;
        }
    }
}
