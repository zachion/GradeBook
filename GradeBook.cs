using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        List<float> grades = new List<float>();

        private string _name;

        public event NameChangedDelegate NameChanged;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }


                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.Existingname = _name;
                    args.NewName = value;

                    NameChanged(this, args);

                }
                _name = value;

            }
        }

        public void WriteGrades(TextWriter destination)
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

        public GradeStatistics ComputeStats()
        {

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

        public void AddGrades(float grade)
        {
            grades.Add(grade);
        }

    }
}
