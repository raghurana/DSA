using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.SupportingClasses
{
    public class GraphNode<T>
    {
        public T Value { get; }

        public IList<GraphNode<T>> Children { get; }

        public GraphNode(T value)
        {
            if(value == null)
                throw new ArgumentException("Value cannot be null");

            Value    = value;
            Children = new List<GraphNode<T>>();
        }

        public void AddChild(GraphNode<T> node)
        {
            Children.Add(node);
        }
    }
}