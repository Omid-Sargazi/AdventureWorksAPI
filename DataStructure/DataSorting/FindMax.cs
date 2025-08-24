namespace DataStructure.DataSorting
{
    public class FindMax
    {
        public static int Run(int[] arr, int left, int right)
        {
            if (left == right)
                return arr[left];

            int mid = (left + right) / 2;

            int maxLeft = Run(arr, left, mid);
            int maxRight = Run(arr, mid + 1, right);

            return Math.Max(maxLeft, maxRight);
        }
    }
}