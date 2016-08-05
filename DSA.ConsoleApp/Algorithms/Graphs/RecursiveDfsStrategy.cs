using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
    public class RecursiveDfsStrategy<T> : BaseGraphTraversalStrategy<T>
    {
        public RecursiveDfsStrategy(PrintNodeProcessor nodeProcessor)
            : base(nodeProcessor)
        {}

        public override void Traverse(GraphNode<T> startNode)
        {
            Traverse(startNode, 0);
        }

        private void Traverse(GraphNode<T> node, int level)
        {
            if (level == 0)
                VisitedCache.Clear();

            if (VisitedCache.Contains(node))
                return;

            VisitedCache.Add(node);

            // Change following 2 statements for pre/post traversal order
            NodeProcessor.Process(node, level);

            foreach (var childNode in node.Children)
                Traverse(childNode, level + 1);
        }
    }
}