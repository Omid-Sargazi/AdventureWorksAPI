namespace AlgorithemAndDataStructure.Sorting
{
    public class SotingInCSharp
    {
        public static void QuickSort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = Partition(arr, lo, hi);
                QuickSort(arr, lo, pivot - 1);
                QuickSort(arr, pivot + 1, hi);

            }
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];
            int i = lo - 1;

            for (int j = lo; j < hi; j++)
            {
                if (arr[j] < arr[pivot])
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }

            return i + 1;
        }


    }

    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger() { }

        public static Logger Instance => _instance;
    }
}