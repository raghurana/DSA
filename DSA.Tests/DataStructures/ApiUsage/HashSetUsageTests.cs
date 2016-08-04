using System.Collections.Generic;
using DSA.Tests.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class HashSetUsageTests
    {
        // http://stackoverflow.com/questions/1247442/when-should-i-use-the-hashsett-type
        private HashSet<ImmutablePerson> hashTable;

        [TestInitialize]
        public void Init()
        {
            hashTable = new HashSet<ImmutablePerson>();
        }

        // Worst case O(1)
        [TestMethod]
        public void AddTest()
        {
            Assert.IsTrue(hashTable.Count == 0);

            var added = hashTable.Add(TestDataMother.TestImmutablePerson1);

            Assert.IsTrue(added);

            added = hashTable.Add(TestDataMother.TestImmutablePerson2);

            Assert.IsTrue(added);

            Assert.IsTrue(hashTable.Count == 2);
        }

        // Worst case O(1)
        [TestMethod]
        public void ContainsTest()
        {
            hashTable.Add(TestDataMother.TestImmutablePerson1);
            hashTable.Add(TestDataMother.TestImmutablePerson2);
            hashTable.Add(TestDataMother.TestImmutablePerson3);

            Assert.IsTrue(hashTable.Contains(TestDataMother.TestImmutablePerson2));

            var compareSet = new List<ImmutablePerson>
            {
                TestDataMother.TestImmutablePerson2,
                TestDataMother.TestImmutablePerson1,
                TestDataMother.TestImmutablePerson3
            };

            Assert.IsTrue( hashTable.SetEquals(compareSet) );
        }

        // Worst case O(1)
        [TestMethod]
        public void RemoveTest()
        {
            hashTable.Add(TestDataMother.TestImmutablePerson2);

            var removed = hashTable.Remove(TestDataMother.TestImmutablePerson2);

            Assert.IsTrue(removed);

            hashTable.Add(TestDataMother.TestImmutablePerson1);

            int removeCount = hashTable.RemoveWhere(p => p.Equals(TestDataMother.TestImmutablePerson1));

            Assert.AreEqual(1, removeCount);
        }
    }
}