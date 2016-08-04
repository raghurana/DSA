using DSA.ConsoleApp.DataStructures.Implementations;
using DSA.ConsoleApp.SupportingClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.DataStructures.Implementations
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
    }
}