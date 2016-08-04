using System.Collections.Generic;

namespace DSA.Tests.SupportingClasses
{
    public class PersonAgePriorityComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age == y.Age)
                return 0;

            if (x.Age > y.Age)
                return 1;

            return -1;
        }
    }
}