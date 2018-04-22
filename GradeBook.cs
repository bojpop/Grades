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
        //public GradeBook()
        //    : this("No name")
        //{
        //    grades = new List<float>();
        //}

        public GradeBook(string name = "There is no name")
        {
            Name = name;
            _grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            if (grade>=0 && grade<=100)
            {
                _grades.Add(grade);
            }
        }

        public GradeStatistics ComputeStatistics()
        {
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

        public void WriteGrades(TextWriter @out)
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

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name!=value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                }
            }
        }

        public event NamedChangedDelegate NameChanged;

        private List<float> _grades;
    }
}
