using System.Collections.Generic;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public class QueueBfsStrategy<T> : IGraphTraversalStrategy<T>
    {
        private readonly PrintNodeProcessor nodeProcessor;
        private readonly Queue<LevelGraphNode<T>> queue     = new Queue<LevelGraphNode<T>>();
        private readonly HashSet<GraphNode<T>> visitedCache = new HashSet<GraphNode<T>>();

        public QueueBfsStrategy(PrintNodeProcessor nodeProcessor)
        {
            this.nodeProcessor = nodeProcessor;
        }

        public void Traverse(GraphNode<T> startNode)
        {
            queue.Clear();
            visitedCache.Clear();

            queue.Enqueue(CreateLevelNode(startNode, 0));

            while (queue.Count > 0)
            {
                var topNode = queue.Dequeue();

                if(visitedCache.Contains(topNode))
                    continue;

                visitedCache.Add(topNode);

                nodeProcessor.Process(topNode, topNode.Level);

                foreach (var child in topNode.Children)
                    queue.Enqueue(CreateLevelNode(child, topNode.Level + 1));
            }     
        }

        private static LevelGraphNode<T> CreateLevelNode(GraphNode<T> node, int level)
        {
            return new LevelGraphNode<T>(node, level);
        }
    }
}