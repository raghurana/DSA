using System;
using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public class StackDfsStrategy<T> : BaseGraphTraversalStrategy<T>
    {
        private readonly Stack<Tuple<GraphNode<T>, int>> stack = new Stack<Tuple<GraphNode<T>, int>>();

        public StackDfsStrategy(PrintNodeProcessor nodeProcessor)
            : base(nodeProcessor)
        {}

        public override void Traverse(GraphNode<T> startNode)
        {
            stack.Clear();
            VisitedCache.Clear();

            stack.Push(CreateNodeTuple(startNode, 0));

            while (stack.Count > 0)
            {
                var topNodeTuple = stack.Pop();

                var topNode      = topNodeTuple.Item1;
                var topNodeLevel = topNodeTuple.Item2;

                if (VisitedCache.Contains(topNode))
                    continue;

                VisitedCache.Add(topNode);

                NodeProcessor.Process(topNode, topNodeLevel);

                foreach (var child in topNode.Children)
                    stack.Push(CreateNodeTuple(child, topNodeLevel + 1));
            }
        }

        private static Tuple<GraphNode<T>, int> CreateNodeTuple(GraphNode<T> node, int level)
        {
            return new Tuple<GraphNode<T>, int>(node, level);
        }
    }
}