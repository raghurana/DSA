using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class DynamicArrayUsageTests
    {
        const string TestString1 = "Test 123";
        const string TestString2 = "Test 234";

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
            
            dynamicArray.Add(TestString1);

            Assert.AreEqual(4, dynamicArray.Capacity);
            Assert.AreEqual(1, dynamicArray.Count);
            Assert.AreEqual(TestString1, dynamicArray[0]);
        }

        // Worst Case O(N)
        [TestMethod]
        public void FindTest()
        {
            dynamicArray.Add(TestString1);
            dynamicArray.Add(TestString2);

            var testString2Index = dynamicArray.IndexOf(TestString2);
            Assert.AreEqual(1, testString2Index);

            var notFound1 = dynamicArray.IndexOf("Random");
            Assert.AreEqual(-1, notFound1);

            var notFound2 = dynamicArray.FindIndex(s => s.Equals("Random"));
            Assert.AreEqual(-1, notFound2);

            testString2Index = dynamicArray.FindIndex(s => s.Equals(TestString2));
            Assert.AreEqual(1, testString2Index);

            Assert.AreEqual(TestString2, dynamicArray.Find(s => s.Equals(TestString2)));
        }

        // Worst Case O(N)
        [TestMethod]
        public void RemoveTest()
        {
            dynamicArray.Add(TestString1);
            dynamicArray.Remove(TestString1);

            Assert.AreEqual(4, dynamicArray.Capacity);
            Assert.AreEqual(0, dynamicArray.Count);
        }
    }
}