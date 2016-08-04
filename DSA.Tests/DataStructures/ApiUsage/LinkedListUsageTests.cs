using System.Collections.Generic;
using DSA.Tests.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class LinkedListUsageTests
    {
        private Person TestPerson1 = new Person {Name = "P1", Age = 33};
        private Person TestPerson2 = new Person {Name = "P2", Age = 55};
        private Person TestPerson3 = new Person {Name = "P3", Age = 77};

        private LinkedList<Person> linkedList;
        
        [TestInitialize]
        public void Init()
        {
            linkedList = new LinkedList<Person>();
        }
            
        [TestMethod]
        public void AddTest()
        {
            var node1 = linkedList.AddFirst(TestPerson1);
            
            Assert.AreEqual(1, linkedList.Count);
            Assert.IsTrue(linkedList.First.Value.Equals(TestPerson1));
            Assert.IsTrue(linkedList.Last.Value.Equals(TestPerson1));
            Assert.IsNull(linkedList.First.Next);
            Assert.IsNull(linkedList.First.Previous);

            linkedList.AddAfter(node1, TestPerson2);

            Assert.AreEqual(2, linkedList.Count);
            Assert.IsTrue(linkedList.Last.Value.Equals(TestPerson2));
            Assert.IsNull(linkedList.Last.Next);
            Assert.IsTrue(linkedList.Last.Previous != null && linkedList.Last.Previous.Value.Equals(TestPerson1));
        }

        [TestMethod]
        public void FindTest()
        {
            var node1 = linkedList.AddFirst(TestPerson1);
            var node2 = linkedList.AddAfter(node1, TestPerson2);
            var node3 = linkedList.AddAfter(node2, TestPerson3);

            var foundNode = linkedList.Find(new Person());

            Assert.IsNull(foundNode);

            foundNode = linkedList.Find(TestPerson2);

            Assert.IsNotNull(foundNode);
            Assert.AreSame(node2.Value, foundNode.Value);
            Assert.AreSame(node2.Previous, foundNode.Previous);
            Assert.AreSame(node2.Next, foundNode.Next);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var node1 = linkedList.AddFirst(TestPerson1);
            var node2 = linkedList.AddAfter(node1, TestPerson2);
            var node3 = linkedList.AddAfter(node2, TestPerson3);

            var removed = linkedList.Remove(TestPerson2);

            Assert.IsTrue(removed);
            Assert.AreSame(node1, linkedList.First);
            Assert.AreSame(node3, linkedList.Last);
            Assert.AreSame(node3, linkedList.First.Next);
        }
    }


}