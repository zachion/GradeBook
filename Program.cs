using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker gradeBook = CreateGradeBook();

            gradeBook.NameChanged += OnNamechanged;

            GetBookName(gradeBook);
            AddGrades(gradeBook);
            SaveGrades(gradeBook);
            WriteResults(gradeBook);

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker gradeBook)
        {
            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();
            WriteResult("Highest Grade: ", gradeStatistics.HighestGrade);
            WriteResult("Lowest Grade: ", (int)gradeStatistics.LowestGrade);
            WriteResult("Avg Grade: ", gradeStatistics.AverageGrade);
            WriteResult(gradeStatistics.Description, gradeStatistics.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker gradeBook)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                gradeBook.WriteGrades(outputFile);
            };
        }

        private static void AddGrades(IGradeTracker gradeBook)
        {
            gradeBook.AddGrade(90.25f);
            gradeBook.AddGrade(56.2F);
            gradeBook.AddGrade(89.50f);
        }

        private static void GetBookName(IGradeTracker gradeBook)
        {
            try
            {
                Console.Write("Enter Name:");
                gradeBook.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }
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
