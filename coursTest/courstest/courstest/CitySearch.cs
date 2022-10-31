using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courstest
{
    public class CitySearch
    {
        private List<string> cities;

        public CitySearch(List<string> cities)
        {
            this.cities = cities;
        }

        public List<string> Search(string term)
        {
            List<string> result = new List<string>();
            if(term.Length < 2)
            {
                if(term == "*")
                {
                    return cities;
                }
                return null;
            }
            else
            {
                cities.ForEach(c =>
                {
                    if (c.ToLower().Contains(term.ToLower()))
                    {
                        result.Add(c);
                    }
                });
                return result;
            }
        }
    }
}
