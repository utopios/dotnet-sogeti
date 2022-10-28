using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestCalculatrice
    {
        [TestMethod]
        public void TestAddition_10_20_30()
        {
            //Pattern AAA
            //A => Arrange
            Calculatrice calculatrice = new Calculatrice();

            //A => Act
            int result = calculatrice.Addition(10, 20);

            //A => Assert
            Assert.AreEqual(30, result);
        }
    }
}
