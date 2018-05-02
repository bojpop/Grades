using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        //public GradeBook()
        //    : this("No name")
        //{
        //    grades = new List<float>();
        //}

        public GradeBook(string name = "There is no name")
        {
            Console.WriteLine("gradebook ctor");
            Name = name;
            _grades = new List<float>();
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }

        public override void DoSomething()
        {
            
        }

        public override void AddGrade(float grade)
        {
            if (grade>=0 && grade<=100)
            {
                _grades.Add(grade);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook compute");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0f;
            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter @out)
        {
            @out.WriteLine("Grades:");
            int i = 0;
            while (i<_grades.Count)
            {
                @out.WriteLine(_grades[i]);
                i++;
            }
            @out.WriteLine("***********");
        }

        

        protected List<float> _grades;
    }
}
