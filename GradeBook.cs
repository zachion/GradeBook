using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        List<float> Grades = new List<float>();

        public GradeStatistics ComputeStats()
        {

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in Grades)
            {
                sum += grade;

                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
            }

            stats.AverageGrade = sum / Grades.Count();

            return stats;
        }



        public void AddGrades(float grade)
        {
            Grades.Add(grade);
        }



    }
}
