using DSA.ConsoleApp.Algorithms.DivideAndConquer;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.DivideAndConquer
{
    [TestClass]
    public class QuickSortAlgoTests
    {
        [TestMethod]
        public void SortTest()
        {
            var sorted = QuickSortAlgo.Sort(TestDataMother.UnsortedArray);
            for (int i = 1; i <= 10; i++)
                Assert.AreEqual(i, sorted[i-1]);
        }
    }
}