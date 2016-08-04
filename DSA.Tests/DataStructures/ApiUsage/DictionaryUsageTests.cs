using System.Collections.Generic;
using DSA.Tests.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class DictionaryUsageTests
    {
        private Dictionary<string, ImmutablePerson> dictionary;
            
        [TestInitialize]
        public void Init()
        {
            dictionary = new Dictionary<string, ImmutablePerson>();
        }

        [TestMethod]
        public void AddTest()
        {
            dictionary.Add(TestDataMother.TestImmutablePerson1.Name, TestDataMother.TestImmutablePerson1);

            Assert.AreEqual(1, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey(TestDataMother.TestImmutablePerson1.Name));
            Assert.IsTrue(dictionary.ContainsValue(TestDataMother.TestImmutablePerson1));
        }

        [TestMethod]
        public void FindTest()
        {
            dictionary.Add(TestDataMother.TestImmutablePerson1.Name, TestDataMother.TestImmutablePerson1);

            var found = dictionary[TestDataMother.TestImmutablePerson1.Name];

            Assert.IsNotNull(found);
            Assert.AreSame(TestDataMother.TestImmutablePerson1, found);
        }

        [TestMethod]
        public void RemoveTest()
        {
            dictionary.Add(TestDataMother.TestImmutablePerson1.Name, TestDataMother.TestImmutablePerson1);

            var removed = dictionary.Remove(TestDataMother.TestImmutablePerson1.Name);

            Assert.IsTrue(removed);
            Assert.AreEqual(0, dictionary.Count);
        }
    }
}