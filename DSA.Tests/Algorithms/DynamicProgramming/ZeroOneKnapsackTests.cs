using System.Collections.Generic;
using DSA.ConsoleApp.Algorithms.DynamicProgramming;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.DynamicProgramming
{
    [TestClass]
    public class ZeroOneKnapsackTests
    {
        [TestMethod]
        public void SimpleThreeItemTest()
        {
            var items = new List<KnapsackItem>()
            {
                new KnapsackItem("Flashlight", value: 3, weight: 2),
                new KnapsackItem("Book", value: 1, weight: 2),
                new KnapsackItem("Pencil", value: 3, weight: 1)
            };

            int solutionValue;
            var bestItems = ZeroOneKnapsack.PickItems(items, 4, out solutionValue);

            Assert.AreEqual(6, solutionValue);
            Assert.AreEqual(2, bestItems.Count);
            Assert.AreEqual(items[2].Name, bestItems[0].Name);
            Assert.AreEqual(items[0].Name, bestItems[1].Name);
        }
    }
}