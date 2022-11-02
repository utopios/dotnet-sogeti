using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public class Roll
    {
        private int _pings;

        public int Pings { get => _pings; }

        public Roll(int pings)
        {
            _pings = pings;
        }
    }
}
