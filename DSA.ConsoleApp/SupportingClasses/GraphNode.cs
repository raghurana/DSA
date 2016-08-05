using System;
using System.Collections.Generic;

namespace DSA.ConsoleApp.SupportingClasses
{
    public class GraphNode<T> : IEquatable<GraphNode<T>>
    {
        public T Value { get; }

        public IList<GraphNode<T>> Children { get; }

        public GraphNode(T value, IList<GraphNode<T>> children = null)
        {
            if (value == null)
                throw new ArgumentException("Value cannot be null");

            Value = value;
            Children = children ?? new List<GraphNode<T>>();
        }

        public void AddChild(GraphNode<T> node)
        {
            Children.Add(node);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 23 * hash + Value.GetHashCode();
            return hash;
        }

        public bool Equals(GraphNode<T> other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class LevelGraphNode<T> : GraphNode<T>
    {
        public int Level { get; }

        public LevelGraphNode(GraphNode<T> node, int level)
            : base(node.Value, node.Children)
        {
            Level = level;
        }
    }
}