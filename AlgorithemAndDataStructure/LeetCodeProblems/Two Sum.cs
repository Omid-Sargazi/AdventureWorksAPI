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
         
    }
}