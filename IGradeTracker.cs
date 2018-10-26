﻿using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
        
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);

        event NameChangedDelegate NameChanged;

        string Name { get; set; }

    }
}