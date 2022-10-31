using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestRandomApp
    {
        [TestMethod]
        public void TestGetRandomByNumberWhenNbIs10ResultShouldBe1()
        {
            RandomApp app = new RandomApp(new FakeApiRandom());

            int result = app.GetRandomByNumber(10);

            Assert.AreEqual(1, result);
        }
    }
}
