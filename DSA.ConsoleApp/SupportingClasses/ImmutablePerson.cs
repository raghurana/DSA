namespace DSA.ConsoleApp.SupportingClasses
{
    public class ImmutablePerson
    {
        public string Name { get; }

        public int Age { get; }

        public ImmutablePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                if (!string.IsNullOrEmpty(Name))
                    hash = hash * 23 + Name.GetHashCode();

                hash = hash*23 + Age.GetHashCode();
                return hash;
            }
        }
    }
}