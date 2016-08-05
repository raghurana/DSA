using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public interface IGraphTraversalStrategy<T>
    {
        void Traverse(GraphNode<T> startNode);
    }

    public abstract class BaseGraphTraversalStrategy<T> : IGraphTraversalStrategy<T>
    {
        protected readonly PrintNodeProcessor NodeProcessor;
        protected readonly HashSet<GraphNode<T>> VisitedCache = new HashSet<GraphNode<T>>();

        protected BaseGraphTraversalStrategy(PrintNodeProcessor nodeProcessor)
        {
            NodeProcessor = nodeProcessor;
        }

        public abstract void Traverse(GraphNode<T> startNode);
    }
}