using System;
using DSA.ConsoleApp.Algorithms.BranchAndBound;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSA.Tests.Algorithms.BranchAndBound
{
    [TestClass]
    public class AssignmentProblemSolverTests
    {
        [TestMethod]
        public void AssignmentTest()
        {
            var costMatrix = new int[4, 4]
            {
                { 3, 5, 9, 2},
                { 9, 3, 3, 4},
                { 1, 4, 2, 6},
                { 5, 3, 7, 2}
            };

            var solver = new AssignmentProblemSolver(costMatrix);
            int solutionCost;
            var assignment = solver.SolveAssignmentProblem(out solutionCost);

            Assert.AreEqual(9, solutionCost);

            Console.WriteLine("Assignment cost: {0}", solutionCost);
            for (var agent = 0; agent < assignment.Count; agent++)
                Console.WriteLine("   Agent {0}: Task {1}", agent, assignment[agent]);
        }
    }
}