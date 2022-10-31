using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class FizzBuzz
    {
        public string StartFizzBuzz(int nb)
        {
            //if(nb%3 == 0 && nb%5 == 0)
            //{
            //    return "FizzBuzz";
            //}
            //else if(nb%3 == 0)
            //{
            //    return "Fizz";
            //}
            //else if(nb%5 == 0)
            //{
            //    return "Buzz";
            //}
            //else
            //{
            //   return nb.ToString();
            //}
            if(nb%3 == 0)
            {
                if(nb%5 == 0)
                {
                    return "FizzBuzz";
                }
                return "Fizz";
            }
            else if(nb%5 == 0)
            {
                return "Buzz";
            }
            return nb.ToString();
        }
    }
}
