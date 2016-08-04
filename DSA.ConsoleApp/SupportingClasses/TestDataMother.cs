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
    }
}