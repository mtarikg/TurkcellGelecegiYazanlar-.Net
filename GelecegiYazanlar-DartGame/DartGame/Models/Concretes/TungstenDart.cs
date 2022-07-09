using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    // Tungsten Dart has an impact in the range of 0.18% to 0.25% to hit a better area when being thrown.
    class TungstenDart : Dart
    {
        public TungstenDart()
        {
            Impact = new Random().Next(18, 26) * 0.01;
        }
    }
}
