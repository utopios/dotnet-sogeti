using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestGradingCalculator
    {
        private GradingCalculator gradingCalculator;


        private void Setup(int score, int attendancePercentage)
        {
            gradingCalculator = new GradingCalculator() { Score = score, AttendancePercentage = attendancePercentage};
        }
        [TestMethod]
        public void TestGetGradeWhenScoreIs95AndAttendancePercentageIs90ShouldBeA()
        {
            //A => Arrange
            //gradingCalculator = new GradingCalculator() { Score = 95, AttendancePercentage = 90 };
            Setup(95, 90);
            //Act
            char result = gradingCalculator.GetGrade();
            //Assert
            Assert.AreEqual('A', result);
        }

        [TestMethod]
        public void TestGetGradeWhenScoreIs85AndAttendancePercentageIs90ShouldBeB()
        {
            //A => Arrange
            gradingCalculator = new GradingCalculator() { Score = 85, AttendancePercentage = 90 };
            //Act
            char result = gradingCalculator.GetGrade();
            //Assert
            Assert.AreEqual('B', result);
        }

        [TestMethod]
        public void TestGetGradeWhenScoreIs65AndAttendancePercentageIs90ShouldBeC()
        {
            //A => Arrange
            gradingCalculator = new GradingCalculator() { Score = 65, AttendancePercentage = 90 };
            //Act
            char result = gradingCalculator.GetGrade();
            //Assert
            Assert.AreEqual('C', result);
        }

        [TestMethod]
        public void TestGetGradeWhenScoreIs50AndAttendancePercentageIs90ShouldBeF()
        {
            //A => Arrange
            gradingCalculator = new GradingCalculator() { Score = 50, AttendancePercentage = 90 };
            //Act
            char result = gradingCalculator.GetGrade();
            //Assert
            Assert.AreEqual('F', result);
        }

    }
}
