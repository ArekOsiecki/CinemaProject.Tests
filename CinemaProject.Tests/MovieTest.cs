using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaProject;
using System.Windows.Input;

namespace CinemaProject.Tests
{
    public class MoviesTest
    {
        
        [Test]
        public void TestRetrieveAllMovies()
        {
           /*Should retrieve all movies from the database*/

           DataSet testSet = Movie.RetrieveAllMovies();

           Assert.That(testSet.Tables.Count > 0);

        }

        [Test]
        public void TestSearchByTitle(string title)
        {
           /* This method should include the following test data:*/

           //Include correct parameter
           DataSet testSet = Movie.SearchByTitle("It");

           Assert.That(testSet.Tables.Count > 0);
           //Null title 
           DataSet testSet2 = Movie.SearchByTitle("");

           Assert.That(testSet2.Tables.Count == 0);

        }

        [Test]
        public void TestSearchByDate()
        {
            /*This method should include the following test data:*/

            //Correct date
            var dateCorrect = new DateTime(2019, 11, 5);
            DataSet testSet = Movie.SearchByDate(dateCorrect);

           Assert.That(testSet.Tables.Count > 0);

            //Incorrect date
            var dateIncorrect = new DateTime(2008, 3, 1);
            DataSet testSet2 = Movie.SearchByDate(dateIncorrect);

           Assert.That(testSet2.Tables.Count == 0);

            //Null date
            var dateNull = new DateTime();
            DataSet testSet3 = Movie.SearchByDate(dateNull);

           Assert.That(testSet3.Tables.Count == 0);

        }

        [Test]
        public void TestSearchByTime()
        {
           /*This method should include the following test data:*/

           // Include correct parameter
           DataSet testSet = Movie.SearchByTime("19:00");

           Assert.That(testSet.Tables.Count > 0);

           //Incorrect parameter 
           DataSet testSet2 = Movie.SearchByTime("08:00");

           Assert.That(testSet2.Tables.Count == 0);

           //Null time
           DataSet testSet3 = Movie.SearchByTime("");

           Assert.That(testSet3.Tables.Count == 0);

        }

        [Test]
        public void TestSearchByTitleAndDate()
        {
            /*Should include the following test data:*/

            //Include both correct parameters 
            var dateCorrect = new DateTime(2019, 11, 5);
            DataSet testSet = Movie.SearchByTitleAndDate("Correct Title", dateCorrect);

            Assert.That(testSet.Tables.Count == 1);

            //Include title and incorrect date
            var dateIncorrect = new DateTime(2008, 3, 1);
            DataSet testSet2 = Movie.SearchByTitleAndDate("Correct Title", dateIncorrect);

            Assert.That(testSet2.Tables.Count == 0);

            //Null title and correct date
            DataSet testSet3 = Movie.SearchByTitleAndDate("", dateCorrect);

            Assert.That(testSet3.Tables.Count == 0);

            //Null title and null date
            var dateNull = new DateTime();
            DataSet testSet4 = Movie.SearchByTitleAndDate("", dateNull);

            Assert.That(testSet4.Tables.Count == 0);

        }
    }
}
