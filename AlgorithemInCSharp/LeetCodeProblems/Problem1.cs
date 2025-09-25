namespace AlgorithemInCSharp.LeetCodeProblems
{
    public class Problem1
    {
        public static bool ContainsDuplicate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[j + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ContainsDuplicate2(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsDuplicate3(int[] arr)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (seen.Add(arr[i])) return true;
            }

            return false;
        }
    }

    public class Problem2
    {
        public static int SingleNumber(int[] arr)
        {
            var counts = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!counts.ContainsKey(item)) counts[item] = 1;
                else
                {
                    counts[item]++;
                }
            }

            foreach (var kv in counts)
            {
                if (kv.Value == 1) return kv.Key;
            }

            return -1;
        }

        public static int SingleNumberXOR(int[] arr)
        {
            int result = 0;
            foreach (var item in arr)
            {
                result ^= item;
            }
            return result;
        }
    }
}