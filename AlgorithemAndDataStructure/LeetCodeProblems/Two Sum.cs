using System.Security.Cryptography.X509Certificates;

namespace AlgorithemAndDataStructure.LeetCodeProblems
{
    public class TwoSum
    {
        public static int[] Run(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                var res = arr[left] + arr[right];
                if (res == target)
                {
                    return new int[] { left, right };
                }
                else if (res < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return null;
        }

        public static void RunTwoSumWithDictionary(int[] arr, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.TryGetValue(target - arr[i], out int index))
                {
                    dict[arr[i]] = i;
                }
                else
                {
                    Console.WriteLine($"{index},{i}");
                    return;
                }
            }
        }

        public static void RunTwoSumWithDictionary2(int[] arr, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(target - arr[i]))
                {
                    Console.WriteLine($"{dict[target - arr[i]]},{i}");
                    return;
                }
                dict[arr[i]] = i;
            }

        }

        public static void CountWords(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                if (wordCount.TryGetValue(word, out int count))
                {
                    wordCount[word] = count + 1;
                }
                else
                {
                    wordCount[word] = 1;
                }

            }
        }

        public static Dictionary<int, long> GenerateFibonacchiSequence(int maxN)
        {
            Dictionary<int, long> fibonacchiCache = new Dictionary<int, long>();

            long Fibonacchi(int n)
            {
                if (fibonacchiCache.TryGetValue(n, out long result))
                {
                    return result;
                }
                if (n <= 1) return n;
                else
                {
                    result = Fibonacchi(n - 1) + Fibonacchi(n - 2);
                    fibonacchiCache[n] = result;
                    return result;
                }
            }

            Fibonacchi(maxN);
            return fibonacchiCache;
        }

        public static void FibonacciIterativeWithCache()
        {
            Dictionary<int, long> cache = new Dictionary<int, long>();

            long Fibo(int n)
            {
                if (n < 0) throw new ArgumentException("n must be non-negative");
                if (n <= 1) return n;

                if (cache.TryGetValue(n, out long result))
                {
                    return result;
                }

                long a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                }

                cache[n] = result;
                return result;
            }

            Console.WriteLine("Fibonacci Sequence (Iterative with Cache):");
            for (int i = 0; i <= 20; i++)
            {
                long fib = Fibo(i);
                Console.WriteLine($"F({i,2}) = {fib,8} {(i % 5 == 0 ? " ←" : "")}");
            }
        }
       
         
    }
}