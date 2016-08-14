using System;
using System.Collections.Generic;
using System.Linq;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.BranchAndBound
{
    public class AssignmentProblemSolver
    {
        private int[,] costMatrix;
        private int[] minimumCosts;
        private int numAgents, numTasks;

        public AssignmentProblemSolver(int[,] costMatrix)
        {
            this.costMatrix = costMatrix;
            numAgents       = numTasks = costMatrix.GetLength(0);

            minimumCosts = new int[numAgents];
            for (var agent = 0; agent < numAgents; agent++)
                minimumCosts[agent] = Enumerable.Range(0, numTasks).Select(task => costMatrix[agent, task]).Min();
        }

        public List<int> SolveAssignmentProblem(out int solutionValue)
        {
            // Find a best guestimate solution by traversing diagonally 
            var bestSolution = new BnBSolutionCandidate();
            for (var task = 0; task < numTasks; task++)
            {
                bestSolution.TaskAssignments.Add(task);
                bestSolution.LowerBound += costMatrix[task, task];
            }

            // Add empty solution as the starting point
            var queue = new C5.IntervalHeap<BnBSolutionCandidate> {new BnBSolutionCandidate()};

            while (!queue.IsEmpty)
            {
                var candidate = queue.DeleteMin();

                for (var task = 0; task < numTasks; task++)
                {
                    if (!candidate.TaskAssignments.Contains(task))
                    {
                        var branchNode = (BnBSolutionCandidate) candidate.Clone();
                        branchNode.TaskAssignments.Add(task);
                        branchNode.LowerBound = CalculateLowerBound(branchNode);

                        if (branchNode.LowerBound >= bestSolution.LowerBound)
                            continue;

                        if (branchNode.TaskAssignments.Count == numTasks)
                            bestSolution = branchNode;
                        else
                            queue.Add(branchNode);
                    }
                }
            }

            solutionValue = bestSolution.LowerBound;
            return bestSolution.TaskAssignments;
        }

        private int CalculateLowerBound(BnBSolutionCandidate branchNode)
        {
            var lowerBound = 0;

            // Sum costs for tasks that already have a fixed agent.
            for (int agent = 0; agent < branchNode.TaskAssignments.Count; agent++)
            {
                var assignedTask = branchNode.TaskAssignments[agent];
                lowerBound += costMatrix[agent, assignedTask];
            }

            // Sum minimum costs of the remaining agents.
            for (int agent = branchNode.TaskAssignments.Count; agent < numAgents; agent++)
                lowerBound += minimumCosts[agent];

            return lowerBound;
        }
    }
}