using System;
using System.Collections.Generic;
using System.Text;

namespace DartGame
{
    // Brass Dart has an impact in the range of 0.02% to 0.09% to hit a better area when being thrown.
    class BrassDart : Dart
    {
        public BrassDart()
        {
            Impact = new Random().Next(2, 10) * 0.01;
        }
    }
}
