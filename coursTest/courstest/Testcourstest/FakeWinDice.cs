using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    public class FakeWinDice : IDice
    {
        public int ThrowDice()
        {
            return 6;
        }
    }
}
