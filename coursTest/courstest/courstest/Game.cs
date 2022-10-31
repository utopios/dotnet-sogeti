using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class Game
    {
        public IDice _dice1;
        public IDice _dice2;

        public Game(IDice dice1, IDice dice2)
        {
            _dice1 = dice1;
            _dice2 = dice2;
        }

        public bool Play()
        {
            int nb1 = _dice1.ThrowDice();
            int nb2 = _dice2.ThrowDice();
            return nb1 == nb2;
        }
    }
}
