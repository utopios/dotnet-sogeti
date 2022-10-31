using courstest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void TestFiboWhenRangeIs5ResultIsAscendant()
        {
            Fibo fibo = new Fibo() { Range = 5};

            List<int> result = fibo.GetFiboSeries();

            List<int> expected = new List<int> { 0, 1, 1, 2, 3};
            //Assert.AreEqual(expected, result);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestFiboWhenRangeIs6ResultShouldContainsList()
        {
            Fibo fibo = new Fibo() { Range = 6 };

            List<int> result = fibo.GetFiboSeries();

            List<int> expected = new List<int> { 0, 1, 1, 2, 3 };
            //Assert.AreEqual(expected, result);
            CollectionAssert.IsSubsetOf(expected, result);
        }
    }
}
