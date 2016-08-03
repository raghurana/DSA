using System;
using DSA.ConsoleApp.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures
{
    [TestClass]
    public class MyDynamicArrayTests
    {
        [TestMethod]
        public void AddTest()
        {
            var list = new MyDynamicArray<string>();
            Assert.AreEqual(list.Capacity, 0);

            const string testString1 = "Test1";
            const string testString2 = "Test2";
            const string testString3 = "Test3";

            list.Add(testString1);

            Assert.IsTrue(list.Contains(testString1));
            Assert.AreEqual(2, list.Capacity);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list.IndexOf(testString1));

            list.Add(testString2);

            Assert.IsTrue(list.Contains(testString2));
            Assert.AreEqual(2, list.Capacity);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(0, list.IndexOf(testString1));
            Assert.AreEqual(1, list.IndexOf(testString2));

            list.Add(testString3);

            Assert.IsTrue(list.Contains(testString3));
            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(0, list.IndexOf(testString1));
            Assert.AreEqual(1, list.IndexOf(testString2));
            Assert.AreEqual(2, list.IndexOf(testString3));
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new MyDynamicArray<string>();
            Assert.AreEqual(list.Capacity, 0);

            const string testString1 = "Test1";
            const string testString2 = "Test2";
            const string testString3 = "Test3";

            list.Add(testString1);
            list.Add(testString2);
            list.Add(testString3);

            Assert.IsFalse(TryRemoveAt(list, 3));
            Assert.IsTrue(TryRemoveAt(list, 2));

            list.Add(testString3);

            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(3, list.Count);

            list.Remove(testString2);

            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(0, list.IndexOf(testString1));
            Assert.AreEqual(1, list.IndexOf(testString3));

            list.Remove(testString1);

            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list.IndexOf(testString3));

            list.Remove(testString3);

            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(0, list.Count);

            list.Remove(testString3);

            Assert.AreEqual(4, list.Capacity);
            Assert.AreEqual(0, list.Count);

            Assert.IsFalse(TryRemoveAt(list, 0));
        }

        private static bool TryRemoveAt(MyDynamicArray<string> list, int index)
        {
            try
            {
                list.RemoveAt(index);
                return true;
            }

            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
    }
}