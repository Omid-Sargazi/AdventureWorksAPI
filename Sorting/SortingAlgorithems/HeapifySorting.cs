namespace Sorting.SortingAlgorithems
{
    public class HeapifySorting
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine($"Before Sorting: {string.Join(",", arr)}");
            HeapMax(arr);
            HeapSort(arr);
            Console.WriteLine($"After Sorting: {string.Join(",", arr)}");
        }


        private static void HeapMax(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, i, n);
            }
        }

        private static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n-1; i >=0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, 0, i);
            }
        }


        private static void Heapify(int[] arr, int i, int n)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (i != largest)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, largest, n);
            }
        }
    }
}