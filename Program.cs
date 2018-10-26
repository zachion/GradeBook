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
            
            gradeBook.NameChanged += OnNamechanged;


            try
            {
                Console.Write("Enter Name:");
                gradeBook.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
      
            gradeBook.AddGrades(91);
            gradeBook.AddGrades(56.2F);
            gradeBook.AddGrades(67);

            gradeBook.WriteGrades(Console.Out);

            GradeStatistics gradeStatistics = gradeBook.ComputeStats();
            gradeBook.Name = "The greatest emperor strikes back";
            gradeBook.Name = "The little puppets inside the conquest of the camelot";
            gradeBook.Name = "Star Wars";

            Console.WriteLine(gradeBook.Name);
            WriteResult("Highest Grade: ", gradeStatistics.HighestGrade);
            WriteResult("Lowest Grade: ", (int)gradeStatistics.LowestGrade);
            WriteResult("Avg Grade: ", gradeStatistics.AverageGrade);
            WriteResult(gradeStatistics.Description, gradeStatistics.LetterGrade);

        }


        private static void OnNamechanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"name changed from {args.Existingname} to {args.NewName}");
        }



        private static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description , result);
        }

        private static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }
    }
}
