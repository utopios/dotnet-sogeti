using Bowling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    internal class RealGenerator : IGenerator
    {
        private Random random;
        public RealGenerator()
        {
            random = new Random();
        }
        public int RandomPins(int max)
        {
            return random.Next(max+1);
        }
    }
}
