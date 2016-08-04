namespace DSA.Tests.SupportingClasses
{
    public static class TestDataMother
    {
        public const string TestString1 = "Test 123";
        public const string TestString2 = "Test 234";
        public const string TestRandomString = "Random";

        public static readonly Person TestPerson1 = new Person { Name = "P1", Age = 33 };
        public static readonly Person TestPerson2 = new Person { Name = "P2", Age = 55 };
        public static readonly Person TestPerson3 = new Person { Name = "P3", Age = 77 };
    }
}