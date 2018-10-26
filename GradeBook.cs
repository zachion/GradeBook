﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook  : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }
        
        protected List<float> grades;

        public override void WriteGrades(TextWriter destination)
        {
            //for (int i = 0; i < grades.Count(); i++)
            //{
            //    destination.WriteLine(grades[i]);
            //}
            for (int i = grades.Count(); i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                sum += grade;

                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
            }

            stats.AverageGrade = sum / grades.Count();

            return stats;
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}
