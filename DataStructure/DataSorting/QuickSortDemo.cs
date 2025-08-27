namespace DataStructure.DataSorting
{
    public class QuickSortDemo
    {
        public static void QuickSort(int[] a) => QuickSort(a, 0, a.Length - 1);

        public static void QuickSort(int[] a, int lo, int hi)
        {
            if (lo >= hi) return;

            // int p =
        }

        public static int Partition(int[] a, int lo, int hi)
        {
            int pivot = a[hi];
            int i = lo - 1;
            for (int j = lo; j < hi; j++)
            {
                if (a[j] <= pivot)
                {
                    i++;
                    (a[i], a[j]) = (a[j], a[i]);
                }
            }
            (a[i + 1], a[hi]) = (a[hi], a[i + 1]);
            return i + 1; 
        }
    }
}