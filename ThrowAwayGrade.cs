using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGrade : GradeBook
    {
        public ThrowAwayGrade(string name)
            :base(name)
        {
            Console.WriteLine("throwaway ctor");
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Throwaway compute");
            float lowest = float.MaxValue;
            foreach (float grade in _grades)
            {
                lowest = Math.Min(lowest, grade);
            }
            Console.WriteLine(lowest);
            _grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}
