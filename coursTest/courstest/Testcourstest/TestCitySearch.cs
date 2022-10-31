using courstest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testcourstest
{
    [TestClass]
    public class TestCitySearch
    {
        private CitySearch citySearch;

        private void Setup(List<string> cities)
        {
            citySearch = new CitySearch(cities);
        }

        [TestMethod]
        public void TestSearchCitiesWhenTermLessThan2ResultShouldBeNull()
        {
            //Arrange
            Setup(new List<string>());
            //Act
            List<string> cities = citySearch.Search("T");
            //Assert
            Assert.IsNull(cities);
        }

        [TestMethod]
        public void TestSearchCitiesWhenTermMoreThan2ResultShouldBeCorrectCitiesStartedWithTerm()
        {
            //Arrange
            Setup(new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York" });
            //Act
            List<string> cities = citySearch.Search("vA");
            //Assert
            CollectionAssert.AreEqual(new List<string>() { "Valence", "Vancouver" }, cities);
        }

        [TestMethod]
        public void TestSearchCitiesWhenTermMoreThan2ResultShouldBeCorrectCitiesThatContainTheTerm()
        {
            //Arrange
            Setup(new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York" });
            //Act
            List<string> cities = citySearch.Search("Er");
            //Assert
            CollectionAssert.AreEqual(new List<string>() { "Rotterdam", "Vancouver", "Amsterdam" }, cities);
        }

        [TestMethod]
        public void TestSearchCitiesWhenTermIsAsteriskResultShouldBeAllCities()
        {
            //Arrange
            List<string> fakeCities = new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York" };
            Setup(fakeCities);
            //Act
            List<string> cities = citySearch.Search("*");
            //Assert
            CollectionAssert.AreEqual(fakeCities, cities);
        }

    }
}
