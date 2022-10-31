using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class Game
    {
        public IDice _dice;

        public Game(IDice dice)
        {
            _dice = dice;
        }

        public bool Play()
        {
            int nb1 = _dice.ThrowDice();
            int nb2 = _dice.ThrowDice();
            return nb1 == nb2;
        }
    }
}
