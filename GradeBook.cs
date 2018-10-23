using System;
using System.Collections.Generic;
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
            Grades = new List<float>();
        }

        List<float> Grades = new List<float>();


        private string _name;


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
                    if(_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        
                        NameChanged(this, args);

                        _name = value;
                    }
                }
             
            }
        }

        public event NameChangedDelegate NameChanged;

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
