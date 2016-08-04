using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class LinkedListUsageTests
    {
        private LinkedList<Person> linkedList;
        
        [TestInitialize]
        public void Init()
        {
            linkedList = new LinkedList<Person>();
        }
            
        // Worst Case O(1) when the right node is found
        [TestMethod]
        public void AddTest()
        {
            var node1 = linkedList.AddFirst(TestDataMother.TestPerson1);
            
            Assert.AreEqual(1, linkedList.Count);
            Assert.IsTrue(linkedList.First.Value.Equals(TestDataMother.TestPerson1));
            Assert.IsTrue(linkedList.Last.Value.Equals(TestDataMother.TestPerson1));
            Assert.IsNull(linkedList.First.Next);
            Assert.IsNull(linkedList.First.Previous);

            linkedList.AddAfter(node1, TestDataMother.TestPerson2);

            Assert.AreEqual(2, linkedList.Count);
            Assert.IsTrue(linkedList.Last.Value.Equals(TestDataMother.TestPerson2));
            Assert.IsNull(linkedList.Last.Next);
            Assert.IsTrue(linkedList.Last.Previous != null && linkedList.Last.Previous.Value.Equals(TestDataMother.TestPerson1));
        }

        // Worst Case O(N) 
        [TestMethod]
        public void FindTest()
        {
            var node1 = linkedList.AddFirst(TestDataMother.TestPerson1);
            var node2 = linkedList.AddAfter(node1, TestDataMother.TestPerson2);
            var node3 = linkedList.AddAfter(node2, TestDataMother.TestPerson3);

            var foundNode = linkedList.Find(new Person());

            Assert.IsNull(foundNode);

            foundNode = linkedList.Find(TestDataMother.TestPerson2);

            Assert.IsNotNull(foundNode);
            Assert.AreSame(node2.Value, foundNode.Value);
            Assert.AreSame(node2.Previous, foundNode.Previous);
            Assert.AreSame(node2.Next, foundNode.Next);
        }

        // Worst Case O(1) when the right node is found
        [TestMethod]
        public void RemoveTest()
        {
            var node1 = linkedList.AddFirst(TestDataMother.TestPerson1);
            var node2 = linkedList.AddAfter(node1, TestDataMother.TestPerson2);
            var node3 = linkedList.AddAfter(node2, TestDataMother.TestPerson3);

            var removed = linkedList.Remove(TestDataMother.TestPerson2);

            Assert.IsTrue(removed);
            Assert.AreSame(node1, linkedList.First);
            Assert.AreSame(node3, linkedList.Last);
            Assert.AreSame(node3, linkedList.First.Next);
        }
    }

}