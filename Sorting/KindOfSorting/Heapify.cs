namespace Sorting.KindOfSorting
{
    public class Heapify
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine("befor Heapify: " + string.Join(", ", arr));
            BuildMaxHeap(arr);
            Console.WriteLine("after Heapify: " + string.Join(", ", arr));
        }

        private static void BuildMaxHeap(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, i, n);
            }
        }

        private static void heapify(int[] arr, int i, int n)
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

            if (largest != i)
            {
                (arr[largest], arr[i]) = (arr[i], arr[largest]);
                heapify(arr, largest,n);
            }

        } 
    }
}