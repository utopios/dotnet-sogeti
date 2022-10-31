using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestGame
    {
        
        [TestMethod]
        public void TestWin()
        {
            Game game = new Game(new FakeWinDice());

            bool result = game.Play();

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestNotWin()
        {
            Game game = new Game(new FakeLoseDice());

            bool result = game.Play();

            Assert.IsFalse(result);
        }
    }
}
