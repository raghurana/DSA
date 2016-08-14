using System;
using System.Collections.Generic;
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

            PrintSolutionAndAssignments(solutionCost, assignment);

            Assert.AreEqual(9, solutionCost);

            var agent = 0;
            Assert.AreEqual(3, assignment[agent++]); 
            Assert.AreEqual(2, assignment[agent++]); 
            Assert.AreEqual(0, assignment[agent++]); 
            Assert.AreEqual(1, assignment[agent]); 
        }

        private void PrintSolutionAndAssignments(int solutionCost, List<int> agentAssignmenst)
        {
            Console.WriteLine("Assignment cost: {0}", solutionCost);
            for (var agent = 0; agent < agentAssignmenst.Count; agent++)
                Console.WriteLine("   Agent {0}: Task {1}", agent, agentAssignmenst[agent]);
        }
    }
}