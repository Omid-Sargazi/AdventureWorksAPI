namespace ReflectionProblems.LeetCodeProblems
{
    public class MaximumProductSubarray
    {
        public static void Run(int[] arr)
        {
            int left = 1;
            int[] res = new int[arr.Length];
            res[0] = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                left = arr[i - 1] * left;
                res[i] = left;
            }

            int right = 1;
            for (int end = arr.Length - 1; end >= 0; end--)
            {
                res[end] = res[end] * right;
                right *= arr[end];
            }

            Console.WriteLine($"{string.Join(",",res)}");
        }
    }
}