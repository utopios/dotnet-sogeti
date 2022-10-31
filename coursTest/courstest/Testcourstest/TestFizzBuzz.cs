using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestFizzBuzz
    {
        [TestMethod]
        public void TestFizzWhenNbIs9ResultShouldBeFizz()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string result = fizzBuzz.StartFizzBuzz(9);
            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void TestFizzWhenNbIs25ResultShouldBeBuzz()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string result = fizzBuzz.StartFizzBuzz(25);
            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void TestFizzWhenNbIs30ResultShouldBeFizzBuzz()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string result = fizzBuzz.StartFizzBuzz(30);
            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod]
        public void TestFizzWhenNbIs17ResultShouldStringNumberFormat()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string result = fizzBuzz.StartFizzBuzz(17);
            Assert.AreEqual("17", result);
        }
    }
}
