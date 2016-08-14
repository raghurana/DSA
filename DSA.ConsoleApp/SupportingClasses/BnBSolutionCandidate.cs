using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.SupportingClasses
{
    public class BnBSolutionCandidate : IComparable<BnBSolutionCandidate>, ICloneable
    {
        public int LowerBound { get; set; }

        public List<int> TaskAssignments { get; }

        public BnBSolutionCandidate(int lowerBound = 0, List<int> taskAssignments = null)
        {
            LowerBound      = lowerBound;
            TaskAssignments = taskAssignments ?? new List<int>();
        }

        public int CompareTo(BnBSolutionCandidate other)
        {
            return LowerBound.CompareTo(other?.LowerBound);
        }

        public object Clone()
        {
            return new BnBSolutionCandidate(LowerBound, new List<int>(TaskAssignments));
        }
    }
}