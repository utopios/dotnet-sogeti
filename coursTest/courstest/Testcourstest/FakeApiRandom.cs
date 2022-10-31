using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    public class FakeApiRandom : IApiRandom
    {
        public int GetRandom(int min, int max)
        {
            return min;
        }
    }
}
