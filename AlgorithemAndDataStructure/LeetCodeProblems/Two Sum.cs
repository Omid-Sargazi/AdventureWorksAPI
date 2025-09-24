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
    }
}