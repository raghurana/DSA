using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.SupportingClasses
{
    public class BnBSolutionCandidate : IComparable, ICloneable
    {
        public int LowerBound;

        public List<int> TasksAssignments;

        public int CompareTo(object obj)
        {
            return LowerBound.CompareTo(((BnBSolutionCandidate)obj).LowerBound);
        }

        public object Clone()
        {
            var clone = new BnBSolutionCandidate
            {
                LowerBound = this.LowerBound,
                TasksAssignments = new List<int>(TasksAssignments)
            };

            return clone;
        }
    }
}