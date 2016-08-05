using System;
using DSA.ConsoleApp.SupportingClasses;

namespace DSA.ConsoleApp.Algorithms.Graphs
{
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