using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook gradeBook = new GradeBook();

            gradeBook.AddGrades(5);
            gradeBook.AddGrades(4);
            gradeBook.AddGrades(3.4f);

            GradeStatistics gradeStatistics = gradeBook.ComputeStats();

            Console.WriteLine(gradeStatistics.AverageGrade);
            Console.WriteLine(gradeStatistics.HighestGrade);
            Console.WriteLine(gradeStatistics.LowestGrade);

        }
    }
}
