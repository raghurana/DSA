namespace DSA.ConsoleApp.Algorithms.DynamicProgramming
{
    public static class CachedFibonacci
    {
        private static readonly long[] FibCache = new long[200];

        public static long GetFibSum(int n)
        {
            if (n <= 1)
                return 1;

            // Means, no item in the cache previously
            if (FibCache[n] == 0)
                FibCache[n] = GetFibSum(n - 1) + GetFibSum(n - 2);

            return FibCache[n];
        }
    }
}