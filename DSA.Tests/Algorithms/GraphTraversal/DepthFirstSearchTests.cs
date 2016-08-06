using DSA.ConsoleApp.Algorithms.GraphTraversal;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.GraphTraversal
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