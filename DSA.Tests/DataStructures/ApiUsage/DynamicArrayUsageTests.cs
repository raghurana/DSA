using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class DynamicArrayUsageTests
    {
        private List<string> dynamicArray;

        [TestInitialize]
        public void Init()
        {
            dynamicArray = new List<string>();
        }
            
        // Worst Case O(N)
        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(0, dynamicArray.Capacity);
            
            dynamicArray.Add(TestDataMother.TestString1);

            Assert.AreEqual(4, dynamicArray.Capacity);
            Assert.AreEqual(1, dynamicArray.Count);
            Assert.AreEqual(TestDataMother.TestString1, dynamicArray[0]);
        }

        // Worst Case O(N)
        [TestMethod]
        public void FindTest()
        {
            dynamicArray.Add(TestDataMother.TestString1);
            dynamicArray.Add(TestDataMother.TestString2);

            var testString2Index = dynamicArray.IndexOf(TestDataMother.TestString2);
            Assert.AreEqual(1, testString2Index);

            var notFound1 = dynamicArray.IndexOf(TestDataMother.TestRandomString);
            Assert.AreEqual(-1, notFound1);

            var notFound2 = dynamicArray.FindIndex(s => s.Equals(TestDataMother.TestRandomString));
            Assert.AreEqual(-1, notFound2);

            testString2Index = dynamicArray.FindIndex(s => s.Equals(TestDataMother.TestString2));
            Assert.AreEqual(1, testString2Index);

            Assert.AreEqual(TestDataMother.TestString2, dynamicArray.Find(s => s.Equals(TestDataMother.TestString2)));
        }

        // Worst Case O(N)
        [TestMethod]
        public void RemoveTest()
        {
            dynamicArray.Add(TestDataMother.TestString1);
            dynamicArray.Remove(TestDataMother.TestString1);

            Assert.AreEqual(4, dynamicArray.Capacity);
            Assert.AreEqual(0, dynamicArray.Count);
        }
    }
}