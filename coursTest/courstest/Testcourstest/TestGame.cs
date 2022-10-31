using courstest;
using Moq;
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
            //Arrange
            //Créer les fakes dice à l'aide  du moq
            var fakeDice1 = Mock.Of<IDice>();
            Mock.Get(fakeDice1).Setup(d => d.ThrowDice()).Returns(3);
           
            //Game game = new Game(new FakeWinDice());
            Game game = new Game(fakeDice1, fakeDice1);
            bool result = game.Play();

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestNotWin()
        {
            //Arrange
            //Créer les fakes dice à l'aide  du moq
            var fakeDice1 = Mock.Of<IDice>();
            Mock.Get(fakeDice1).Setup(d => d.ThrowDice()).Returns(3);
            var fakeDice2 = Mock.Of<IDice>();
            Mock.Get(fakeDice2).Setup(d => d.ThrowDice()).Returns(4);
            Game game = new Game(fakeDice1, fakeDice2);

            bool result = game.Play();

            Assert.IsFalse(result);
        }
    }
}
