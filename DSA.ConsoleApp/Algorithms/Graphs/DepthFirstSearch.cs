using System;
using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public class DepthFirstSearch
    {
        private readonly IGraphTraversalStrategy<string> traversalStrategy;

        public DepthFirstSearch(bool useRecursiveStratgey = true)
        {
            if (useRecursiveStratgey)
                traversalStrategy = new RecursiveGraphTraversalStrategy<string>(new PrintNodeProcessor());
            else
                traversalStrategy = new StackGraphTraversalStrategy<string>(new PrintNodeProcessor());
        }

        public void Process(GraphNode<string> graph)
        {
            traversalStrategy.Traverse(graph);
        }
    }

    public interface IGraphTraversalStrategy<T>
    {
        void Traverse(GraphNode<T> startNode);
    }

    public class RecursiveGraphTraversalStrategy<T> : IGraphTraversalStrategy<T>
    {
        private HashSet<GraphNode<T>> visitedCache;
        private readonly PrintNodeProcessor nodeProcessor;

        public RecursiveGraphTraversalStrategy(PrintNodeProcessor nodeProcessor)
        {
            this.nodeProcessor = nodeProcessor;
        }

        public void Traverse(GraphNode<T> startNode)
        {
            Traverse(startNode, 0);
        }

        private void Traverse(GraphNode<T> node, int level)
        {
            if (level == 0)
                visitedCache = new HashSet<GraphNode<T>>();

            if (visitedCache.Contains(node))
                return;

            visitedCache.Add(node);

            // Change following 2 statements for pre/post traversal order
            nodeProcessor.Process(node, level);
            foreach (var childNode in node.Children)
                Traverse(childNode, level + 1);
        }
    }

    public class StackGraphTraversalStrategy<T> : IGraphTraversalStrategy<T>
    {
        private readonly PrintNodeProcessor nodeProcessor;
        private readonly Stack<Tuple<GraphNode<T>, int>> stack  = new Stack<Tuple<GraphNode<T>, int>>();
        private readonly HashSet<GraphNode<T>> visitedCache     = new HashSet<GraphNode<T>>();

        public StackGraphTraversalStrategy(PrintNodeProcessor nodeProcessor)
        {
            this.nodeProcessor = nodeProcessor;
        }

        public void Traverse(GraphNode<T> startNode)
        {
            stack.Clear();
            visitedCache.Clear();

            stack.Push(new Tuple<GraphNode<T>, int>(startNode, 0));

            while (stack.Count > 0)
            {
                var popNodeTuple = stack.Pop();

                if(visitedCache.Contains(popNodeTuple.Item1))
                    return;

                var currentNode = popNodeTuple.Item1;
                var currentLevel = popNodeTuple.Item2;

                visitedCache.Add(currentNode);

                nodeProcessor.Process(currentNode, currentLevel);
                foreach (var child in currentNode.Children)
                    stack.Push(new Tuple<GraphNode<T>, int>(child, currentLevel + 1));
            }
        }
    }
    
    public class PrintNodeProcessor
    {
        private const int Indent = 2;

        public void Process<T>(GraphNode<T> node, int currentLevel = 0)
        {
            var originalString  = node.Value.ToString();
            var levelIndent     = (currentLevel * Indent) + originalString.Length;

            // Pad Left requires the total width to be padded for right alignment.
            Console.WriteLine(originalString.PadLeft(levelIndent, ' '));
        }
    }
}