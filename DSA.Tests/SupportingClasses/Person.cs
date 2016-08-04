using System;
using System.Globalization;

namespace DSA.Tests.SupportingClasses
{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; } 

        public int Age { get; set; }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return
                StringComparer
                    .Create(CultureInfo.CurrentCulture, false)
                    .Equals(Name, other.Name) && Age == other.Age;
        }
    }
}