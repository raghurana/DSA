namespace DSA.ConsoleApp.SupportingClasses
{
    public class KnapsackItem
    {
        public string Name { get; }

        public int Value { get; } 

        public int Weight { get; }

        public KnapsackItem(string name, int value, int weight)
        {
            Value = value;
            Weight = weight;
            Name = name;
        }
    }
}