using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.GraphTraversal
{
    public class BreadthFirstSearch
    {
        private readonly IGraphTraversalStrategy<string> traversalStrategy;

        public BreadthFirstSearch()
        {
            traversalStrategy = new QueueBfsStrategy<string>(new PrintNodeProcessor());
        }

        public void Process(GraphNode<string> graph)
        {
            traversalStrategy.Traverse(graph);
        }
    }
}