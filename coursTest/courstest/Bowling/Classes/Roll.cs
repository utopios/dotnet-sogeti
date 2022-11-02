using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public class Roll
    {
        private int _pins;

        public int Pins { get => _pins; }

        public Roll(int pins)
        {
            _pins = pins;
        }
    }
}
