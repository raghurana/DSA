using DSA.ConsoleApp.Algorithms.Graphs;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.Graphs
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        [TestMethod]
        public void QueueTest()
        {
            var bfs = new BreadthFirstSearch();
            bfs.Process(TestDataMother.CreateTestGraph());
        }
    }
}