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

            gradeBook.Name = "The greatest emperor strikes back";
            Console.WriteLine(gradeBook.Name);
            WriteResult("Highest Grade: ", gradeStatistics.HighestGrade);
            WriteResult("Lowest Grade: ", (int)gradeStatistics.LowestGrade);
            WriteResult("Avg Grade: ", gradeStatistics.AverageGrade);
   
        }

        private static void WriteResult(string description, int result)
        {
            Console.WriteLine("{0} : {1}", description , result);
        }

        private static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }
    }
}
