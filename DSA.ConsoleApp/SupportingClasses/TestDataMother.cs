using System.Collections.Generic;

namespace DSA.ConsoleApp.SupportingClasses
{
    public static class TestDataMother
    {
        public const string TestString1 = "Test 123";
        public const string TestString2 = "Test 234";
        public const string TestRandomString = "Random";

        public static readonly Person TestPerson1 = new Person { Name = "P1", Age = 33 };
        public static readonly Person TestPerson2 = new Person { Name = "P2", Age = 55 };
        public static readonly Person TestPerson3 = new Person { Name = "P3", Age = 77 };

        public static readonly ImmutablePerson TestImmutablePerson1 = new ImmutablePerson("IP1", 20);
        public static readonly ImmutablePerson TestImmutablePerson2 = new ImmutablePerson("IP2", 30);
        public static readonly ImmutablePerson TestImmutablePerson3 = new ImmutablePerson("IP3", 40);

        public static GraphNode<string> CreateTestGraph()
        {
            var frozen = new GraphNode<string>("frozen");
            frozen.AddChild(new GraphNode<string>("peas"));
            frozen.AddChild(new GraphNode<string>("beans"));
            frozen.AddChild(new GraphNode<string>("spinach"));

            var vegetables = new GraphNode<string>("vegetables");
            vegetables.AddChild(frozen);

            var meat = new GraphNode<string>("meat");
            meat.AddChild(new GraphNode<string>("chicken"));
            meat.AddChild(new GraphNode<string>("beef"));

            var main = new GraphNode<string>("main");
            main.AddChild(meat);
            main.AddChild(vegetables);

            frozen.AddChild(main); // Introduce a "cycle" (even though it is meaningless here)
            return main;
        }

        public static readonly List<int> UnsortedArray = new List<int> {4, 1, 2, 6, 7, 10, 3, 5, 9, 8};
    }
}