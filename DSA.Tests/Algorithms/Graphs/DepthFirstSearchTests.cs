using DSA.ConsoleApp.Algorithms.Graphs;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.Graphs
{
    [TestClass]
    public class DepthFirstSearchTests
    {
        [TestMethod]
        public void RecursiveTest()
        {
            var dfs = new DepthFirstSearch();

            dfs.Process(TestDataMother.CreateTestGraph());
        }

        [TestMethod]
        public void StackTest()
        {
            var dfs = new DepthFirstSearch(useRecursiveStratgey: false);

            dfs.Process(TestDataMother.CreateTestGraph());
        }
    }
}