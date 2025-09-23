namespace AlgorithemInCSharp.Lists
{
    public static class WhereWithYield
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Console.WriteLine("Starting Where");

            foreach (var item in source)
            {
                Console.WriteLine($"Checking item: {item}");
                if (predicate(item))
                {
                    Console.WriteLine($"Yielding item: {item}");
                    yield return item;
                }
            }
            Console.WriteLine("Finished Where");


            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = numbers.Where(x => x % 2 == 0);
        }
        
    }
}