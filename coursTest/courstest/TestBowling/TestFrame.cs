using Bowling.Classes;
using Bowling.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBowling
{
    [TestClass]
    public class TestFrame
    {

        private IGenerator generator;

        private void Setup()
        {
            generator = Mock.Of<IGenerator>();
        }

        [TestMethod]
        public void Test_SimpleFrameFirstRoll_CheckScore()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(false, generator);
            //Act
            frame.Roll();
            //Assert 
            Assert.AreEqual(3, frame.Score);
        }

        [TestMethod]
        public void Test_SimpleFrameFirstRoll_CheckReturnTrue()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(false, generator);
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_SimpleFrameWithStrike_CheckReturnFalse()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(false, generator) { Rolls = new List<Roll>() { new Roll(10)} };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_SimpleFrameSecondRoll_CheckScore()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(6)).Returns(3);
            Frame frame = new Frame(false, generator) { Rolls = new List<Roll>() { new Roll(4)} };
            //Act
            frame.Roll();
            //Assert 
            Assert.AreEqual(7, frame.Score);
        }

        [TestMethod]
        public void Test_SimpleFrameThirdRoll_ReturnFalse()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(false, generator) { Rolls = new List<Roll>() { new Roll(4), new Roll(3) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_LastFrameSecondRollAfterStrike_ReturnTrue()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(10)} };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test_LastFrameSecondRollAfterStrike_CheckScore()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(10) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.AreEqual(13, frame.Score);
        }
        [TestMethod]
        public void Test_LastFrameThirdRollAfterStrike_ReturnTrue()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(6)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(10), new Roll(4) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_LastFrameThirdRollAfterStrike_ChekScore()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(6)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(10), new Roll(4) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.AreEqual(17,frame.Score);
        }

        [TestMethod]
        public void Test_LastFrameThirdRollAfterSpare_ReturnTrue()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(6), new Roll(4) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_LastFrameThirdRollAfterSpare_ChekScore()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(6), new Roll(4) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.AreEqual(13, frame.Score);
        }

        [TestMethod]
        public void Test_LastFrameFourthRoll_ReturnFalse()
        {
            //Arrange
            Setup();
            Mock.Get(generator).Setup(g => g.RandomPins(10)).Returns(3);
            Frame frame = new Frame(true, generator) { Rolls = new List<Roll>() { new Roll(6), new Roll(4), new Roll(10) } };
            //Act
            bool result = frame.Roll();
            //Assert 
            Assert.IsFalse(result);
        }
    }
}
