using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    public class FakeLoseDice : IDice
    {
        private bool notSame = true;

        public int ThrowDice()
        {
            notSame = !notSame;
            if (notSame)
            {  
                return 3;
            }else
            {
                return 2;
            }

        }
    }
}
