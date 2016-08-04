using System.Collections.Generic;
using C5;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.ApiUsage
{
    [TestClass]
    public class PriorityQueueUsageTests
    {
        // Uses Age as the priority, the older the person, higher the priority.
        private readonly IComparer<Person> ageComparer = new PersonAgePriorityComparer();
        private IntervalHeap<Person> priorityQueue;
            
        [TestInitialize]
        public void Init()
        {
            priorityQueue = new IntervalHeap<Person>(ageComparer);
        }
            
        // Worst Case O(log n)
        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add(TestDataMother.TestPerson1);
            priorityQueue.Add(TestDataMother.TestPerson2);
            priorityQueue.Add(TestDataMother.TestPerson3);

            Assert.AreEqual(priorityQueue.Count, 3);
        }

        // Worst Case O(1) as we are only fetching the highest priority 
        [TestMethod]
        public void FindTest()
        {
            priorityQueue.Add(TestDataMother.TestPerson1);
            priorityQueue.Add(TestDataMother.TestPerson2);
            priorityQueue.Add(TestDataMother.TestPerson3);

            var highestPriority = priorityQueue.FindMax();

            Assert.AreSame(TestDataMother.TestPerson3, highestPriority);
            Assert.AreEqual(3, priorityQueue.Count);

            var lowestPriority = priorityQueue.FindMin();

            Assert.AreSame(TestDataMother.TestPerson1, lowestPriority);
            Assert.AreEqual(3, priorityQueue.Count);
        }

        // Worst Case O(log n)
        [TestMethod]
        public void RemoveTest()
        {
            //priorityQueue
            priorityQueue.Add(TestDataMother.TestPerson1);
            priorityQueue.Add(TestDataMother.TestPerson2);
            priorityQueue.Add(TestDataMother.TestPerson3);

            var deletedPerson =  priorityQueue.DeleteMax();

            Assert.AreSame(TestDataMother.TestPerson3, deletedPerson);

            var newMax = priorityQueue.FindMax();
            var newMIn = priorityQueue.FindMin();

            Assert.AreSame(TestDataMother.TestPerson2, newMax);
            Assert.AreSame(TestDataMother.TestPerson1, newMIn);
        }
    }
}