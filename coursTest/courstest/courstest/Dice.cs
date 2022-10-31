using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class Dice : IDice
    {
        public int ThrowDice()
        {
            return new Random().Next(1, 7);
        }
    }
}
