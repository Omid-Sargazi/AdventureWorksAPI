using System.Security.AccessControl;

namespace Sorting.SortingAlgorithems
{
    public class Sortingg
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine($"Before Heapify:{string.Join(",", arr)}");

            FindMaxHeap(arr);

            Console.WriteLine($"Before Heapify:{string.Join(",", arr)}");
        }

        private static void FindMaxHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, i, n);
            }
        }

        private static void Heapify(int[] arr, int i,int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

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
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, largest,n);
            }
        }
    }
}