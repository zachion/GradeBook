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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }


        private string _name;

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
