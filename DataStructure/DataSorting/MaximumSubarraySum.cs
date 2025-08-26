namespace DataStructure.DataSorting
{
    public class MaximumSubarraySum
    {

        public static int MaxCrossingSum(int[] arr, int start, int mid, int end)
        {
            int sum = 0;
            int leftSum = int.MinValue;

            for (int i = mid; i >= start; i--)
            {
                sum += arr[i];
                if (sum > leftSum) leftSum = sum;
            }


            sum = 0;
            int rightSum = int.MinValue;

            for (int i = mid + 1; i <= end; i++)
            {
                sum += arr[i];
                if (sum > rightSum) rightSum = sum;
            }

            return rightSum + leftSum;
        }
        public static int Run(int[] arr, int start, int end)
        {
            if (start == end) return arr[start];

            int mid = start + (end - start) / 2;

            int leftMax = Run(arr, start, mid);
            int rightMax = Run(arr, mid + 1, end);
            int CrossMax = MaxCrossingSum(arr, start, mid, end);

            int bigger = (leftMax > rightMax) ? leftMax : rightMax;
            int result = (bigger > CrossMax) ? bigger : CrossMax;
            // return Math.Max(Math.Max(leftMax, rightMax), CrossMax);
            return result;
            
        }
    }
}