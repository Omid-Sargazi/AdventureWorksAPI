using System.Globalization;
using System.Runtime.Intrinsics.Arm;
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

        private static void Heapify(int[] arr, int i, int n)
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
                Heapify(arr, largest, n);
            }
        }

        public static void Bubble(int[] arr)
        {
            for (int start = arr.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }


                if (!swapped)
                {
                    break;
                }
            }

            Console.WriteLine($"Bubble sort: {string.Join(",", arr)}");
        }

        public static void Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                }
            }


            Console.WriteLine($"Selection sort: {string.Join(",", arr)}");

        }

        public static void Insertion(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int current = arr[i];
                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = current;
            }
            Console.WriteLine($"Insertion sort: {string.Join(",", arr)}");

        }


        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;
            int n = arr.Length;
            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, right.Length);
            Console.WriteLine($"Left: {string.Join(",", left)}");
            Console.WriteLine($"Right: {string.Join(",", right)}");

            MergeSort(left);
            MergeSort(right);
            Merge(arr, left, right);
        }

        private static void Merge(int[] result, int[] left, int[] right)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int n1 = left.Length;
            int n2 = right.Length;

            while (p1 < n1 && p2 < n2)
            {
                if (left[p1] < right[p2])
                {
                    result[p3] = left[p1];
                    p1++;
                }
                else
                {
                    result[p3] = right[p2];
                    p2++;
                }

                p3++;
            }

            while (p1 < n1)
            {
                result[p3] = left[p1];
                p1++;
                p3++;
            }
            while (p2 < n2)
            {
                result[p3] = right[p2];
                p3++;
                p2++;
            }

            Console.WriteLine($"Merge Sort: {string.Join(",", result)}");

        }


        public static void QuickSort(int[] arr, int lo, int hi)
        {

            int pi = Partition(arr, lo, hi);
            QuickSort(arr, lo, pi - 1);
            QuickSort(arr, pi + 1, hi);
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int i = lo - 1;
            int pi = arr[hi];
            for (int j = 0; j < hi; j++)
            {
                if (arr[j] < pi)
                {
                    i++;
                    (arr[j], arr[i]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[hi]) = (arr[hi], arr[i + 1]);
            return i + 1;
        }
    }
}