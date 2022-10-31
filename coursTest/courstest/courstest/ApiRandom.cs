using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class ApiRandom : IApiRandom
    {
        public int GetRandom(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
