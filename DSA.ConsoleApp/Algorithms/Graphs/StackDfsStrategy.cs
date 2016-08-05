using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public class StackDfsStrategy<T> : BaseGraphTraversalStrategy<T>
    {
        private readonly Stack<LevelGraphNode<T>> stack = new Stack<LevelGraphNode<T>>();

        public StackDfsStrategy(PrintNodeProcessor nodeProcessor)
            : base(nodeProcessor)
        {}

        public override void Traverse(GraphNode<T> startNode)
        {
            stack.Clear();
            VisitedCache.Clear();

            stack.Push(CreateLevelNode(startNode, 0));

            while (stack.Count > 0)
            {
                var topNode = stack.Pop();
                if (VisitedCache.Contains(topNode))
                    continue;

                VisitedCache.Add(topNode);
                NodeProcessor.Process(topNode, topNode.Level);
                foreach (var child in topNode.Children)
                    stack.Push(CreateLevelNode(child, topNode.Level + 1));
            }
        }

        private static LevelGraphNode<T> CreateLevelNode(GraphNode<T> node, int level)
        {
            return new LevelGraphNode<T>(node, level);
        }
    }
}