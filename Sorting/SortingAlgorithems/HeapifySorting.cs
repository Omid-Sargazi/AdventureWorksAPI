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
            for (int i = n - 1; i >= 0; i--)
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


    public class Sortings
    {
        public static void Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
            }


            Console.WriteLine($"Seelction: {string.Join(", ", arr)}");
        }


        public static void Insertion(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int current = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = current;
            }

            Console.WriteLine($"Insertion Sort: {string.Join(", ", arr)}");

        }
    }
}