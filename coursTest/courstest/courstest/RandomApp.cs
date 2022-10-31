using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class RandomApp
    {
        private IApiRandom _apiRandom;

        public RandomApp(IApiRandom apiRandom)
        {
            _apiRandom = apiRandom;
        }
        public int GetRandomByNumber(int nb)
        {
            if(nb%2==0)
            {
                return _apiRandom.GetRandom(1,100);
            }
            else
            {
                return _apiRandom.GetRandom(100,200);
            }
        }
    }
}
