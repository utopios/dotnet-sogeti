using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestFibo
    {

        public void TestAscendant()
        {
            Fibo fibo = new Fibo() { Range = 5};

            List<int> result = fibo.GetFiboSeries();

            List<int> expected = new List<int> { 0, 1, 1, 2, 3};
            Assert.AreEqual(expected, result);
        }
    }
}
