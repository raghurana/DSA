using System.Diagnostics;
using DSA.ConsoleApp.Algorithms.DynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.DynamicProgramming
{
    [TestClass]
    public class CachedFibonacciTests
    {
        [TestMethod]
        public void FibTestForLargeValue()
        {
            // Without a cached implementation, the complexity would be O(2^N) which is very high for even small values like 80
            var sum = CachedFibonacci.GetFibSum(100);
            Assert.AreEqual(1298777728820984005, sum);
        }
    }
}