namespace StandardExamples.Problems1
{
    public class LeetCodeProblems
    {
        public static bool Palindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            string clean = s.ToLower();

            while (left < right)
            {
                while (left < right && IsValidChar(clean[left])) left++;
                while (left < right && IsValidChar(clean[right])) right--;


                if (clean[left] != clean[right]) return false;

                left++;right--;
            }
            return true;
        }

        private static bool IsValidChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }

        public static int MaximumSubarray(int[] arr)
        {
            int maxSum = arr[0];
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum = Math.Max(sum, arr[i] + sum);

                maxSum = Math.Max(sum, maxSum);
            }
            return maxSum;
        }
        
        public static int MaximumProductSubarray(int[] arr)
        {
            int maxProduct = arr[0];
            int minProduct = arr[0];
            int result = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                int temp = maxProduct;

                maxProduct = Math.Max(arr[i], Math.Max(maxProduct * arr[i], minProduct * arr[i]));
                minProduct = Math.Min(arr[i], Math.Min(temp * arr[i], minProduct * arr[i]));
            }

            return Math.Max(maxProduct,)
        }
    }
}