using System.Runtime.Intrinsics.Arm;

namespace Sorting.KindOfSorting
{
    public class HeapifySortingg
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine($"Before Heaping:{string.Join(",", arr)}");
            MaxHeap(arr);
            SortHeap(arr);
            Console.WriteLine($"After Heaping:{string.Join(",", arr)}");
        }

        private static void MaxHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, i,n);
            }
        }

        private static void SortHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n - 1; i >= 1; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, 0,i);
            }
        }

        private static void Heapify(int[] arr, int i, int n)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            //int n = arr.Length;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, largest,n);
            }
        }
    }
   
}