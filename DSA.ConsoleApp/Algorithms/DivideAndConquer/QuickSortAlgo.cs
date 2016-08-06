using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.Algorithms.DivideAndConquer
{
    public static class QuickSortAlgo
    {
        private static readonly Random Random = new Random();

        public static List<T> Sort<T>(List<T> elements)
            where T : IComparable
        {
            if (elements.Count <= 1)
                return elements;

            var pivotIndex = Random.Next(elements.Count);
            var smaller    = new List<T>();
            var larger     = new List<T>();

            for (int i = 0; i < elements.Count; i++)
            {
                if(i == pivotIndex)
                    continue;

                if (elements[i].CompareTo(elements[pivotIndex]) < 0)
                    smaller.Add(elements[i]);
                else
                    larger.Add(elements[i]);
            }

            var mergedSolution = Sort(smaller);
            mergedSolution.Add(elements[pivotIndex]);
            mergedSolution.AddRange(Sort(larger));

            return mergedSolution;
        }  
    }
}