using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.GraphTraversal
{
    public class DepthFirstSearch
    {
        private readonly IGraphTraversalStrategy<string> traversalStrategy;

        public DepthFirstSearch(bool useRecursiveStratgey = true)
        {
            if (useRecursiveStratgey)
                traversalStrategy = new RecursiveDfsStrategy<string>(new PrintNodeProcessor());
            else
                traversalStrategy = new StackDfsStrategy<string>(new PrintNodeProcessor());
        }

        public void Process(GraphNode<string> graph)
        {
            traversalStrategy.Traverse(graph);
        }
    }   
}