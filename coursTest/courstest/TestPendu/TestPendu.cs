using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Classes;
using TP03.Interfaces;

namespace TestPendu
{
    [TestClass]
    public class TestPendu
    {
        private IGenerateur generateur;
        private LePendu pendu;


        private void Setup()
        {
            generateur = Mock.Of<IGenerateur>();
            Mock.Get(generateur).Setup(g => g.Generer()).Returns("toto");
            pendu = new LePendu(10, generateur);
        }

        [TestMethod]
        public void TestGenererMasque()
        {
            //arrange
            Setup();
            //assert
            Assert.AreEqual("****", pendu.Masque);
        }

        [TestMethod]
        public void TestCharExistMasque()
        {
            //arrange
            Setup();
            //Act
            pendu.TestChar('t');

            //Assert
            Assert.AreEqual("t*t*", pendu.Masque);
        }

        [TestMethod]
        public void TestCharExistNbEssai()
        {
            //arrange
            Setup();
            //Act
            pendu.TestChar('t');

            //Assert
            Assert.AreEqual(10, pendu.NbEssai);
        }

        [TestMethod]
        public void TestCharNotExistMasque()
        {
            //arrange
            Setup();
            pendu.TestChar('t');
            //Act
            pendu.TestChar('a');
            //Assert
            Assert.AreEqual("t*t*", pendu.Masque);
        }

        [TestMethod]
        public void TestCharNotExistNbEssai()
        {
            //arrange
            Setup();
            //Act
            pendu.TestChar('a');
            //Assert
            Assert.AreEqual(9, pendu.NbEssai);
        }

        [TestMethod]
        public void TestWinFalse()
        {
            //arrange
            Setup();
            pendu.TestChar('a');
            bool result = pendu.TestWin();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestWinTrue()
        {
            //arrange
            Setup();
            pendu.TestChar('t');
            pendu.TestChar('o');
            bool result = pendu.TestWin();
            Assert.IsTrue(result);
        }
    }
}
