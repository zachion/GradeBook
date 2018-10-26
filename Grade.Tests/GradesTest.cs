using Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradesTest
    {

        [TestMethod]
        public void TestArrayts()
        {
            float[] myFloat = new float[3];

            AddToArray(myFloat);

            Assert.AreEqual(33.5f, myFloat[2]);
        }

        private void AddToArray(float[] myFloat)
        {
           
            myFloat[2] = 33.5f;
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime myDate = new DateTime(2015,1,1);
            myDate = myDate.AddDays(1);

            Assert.AreEqual(2, myDate.Day);
        }


        [TestMethod]
        public void TestValueType()
        {

            int x = 5;
            IncrementByOne(x);

            Assert.AreEqual(5, x);
        }

        private static void IncrementByOne(int x)
        {
            x += 1;
        }

        [TestMethod]
        public void TestReferenceTypes()
        {

            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GieveBookAName(book2);


            Assert.AreEqual("John Carpenters Novels", book2.Name);
        }

        private void GieveBookAName(GradeBook book)
        {
            book.Name = "John Carpenters Novels";
        }

        [TestMethod]
        public void CompareString()
        {

            string name = "john";
            string name2 = "John";


            bool strComparison = String.Equals(name, name2,StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(strComparison);
        }

        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(5);
            book.AddGrade(4);
            book.AddGrade(3.4f);

            GradeStatistics Stats = book.ComputeStatistics();

            Assert.AreEqual(5, Stats.HighestGrade);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook Book = new GradeBook();

            Book.AddGrade(5);
            Book.AddGrade(4);
            Book.AddGrade(3.4f);

            GradeStatistics Stats = Book.ComputeStatistics();

            Assert.AreEqual(3.4f, Stats.LowestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook Book = new GradeBook();

            Book.AddGrade(5);
            Book.AddGrade(4);
            Book.AddGrade(3.4f);

            GradeStatistics Stats = Book.ComputeStatistics();

            Assert.AreEqual(4.13f, Stats.AverageGrade, 0.01);
        }

        [TestMethod]
        public void CheckNames()
        {
            GradeBook Book1 = new GradeBook();
            GradeBook Book2 = Book1;

            Book2.Name = "asdad";

            Assert.AreEqual(Book1.Name, Book2.Name);
        }

    }
}
