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
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrades(5);
            book.AddGrades(4);
            book.AddGrades(3.4f);

            GradeStatistics Stats = book.ComputeStats();

            Assert.AreEqual(5, Stats.HighestGrade);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook Book = new GradeBook();

            Book.AddGrades(5);
            Book.AddGrades(4);
            Book.AddGrades(3.4f);

            GradeStatistics Stats = Book.ComputeStats();

            Assert.AreEqual(3.4f, Stats.LowestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook Book = new GradeBook();

            Book.AddGrades(5);
            Book.AddGrades(4);
            Book.AddGrades(3.4f);

            GradeStatistics Stats = Book.ComputeStats();

            Assert.AreEqual(4.13f, Stats.AverageGrade, 0.01);
        }

    }

    

}
