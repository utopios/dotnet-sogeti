using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Interfaces
{
    public interface IGenerator
    {
        public int RandomPins(int max);
    }
}
