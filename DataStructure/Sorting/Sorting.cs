namespace DataStructure.Sorting
{
    public class BubbleSort
    {
        public static void Bubble(int[] arr)
        {
            for (int start = arr.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(",", arr));
        }
    }


    public class SelectionSort
    {
        public static void Run(int[] arr)
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

            Console.WriteLine(string.Join(",", arr));
        }
    }

    public class InsertionSort
    {
        public static void Run(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; i++)
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

            Console.WriteLine(string.Join(",", arr));
        }
    }

    public class MergeTwoArre
    {
        public static void Run(int[] arr1, int[] arr2)
        {
            int arr1Length = arr1.Length;
            int arr2Length = arr2.Length;

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int[] arr3 = new int[arr1Length + arr2Length];

            while (p1 < arr1.Length && p2 < arr1.Length)
            {
                if (arr1[p1] <= arr2[p2])
                {
                    arr3[p3] = arr1[p1];
                    p1++;
                }
                else
                {
                    arr3[p3] = arr2[p2];
                    p2++;
                }

                p3++;
            }

            while (p1 < arr1.Length)
            {
                arr3[p3] = arr1[p1];
                p1++;
                p3++;
            }

            while (p2 < arr2.Length)
            {
                arr3[p3] = arr2[p2];
                p2++;
                p3++;
            }


            Console.WriteLine(string.Join(",", arr3));
        }
    }

    public class MegerTowEqualLength
    {
        public static void Run(int[] arr1, int[] arr2)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int n1 = arr1.Length;
            int n2 = arr2.Length;
            int n3 = n1 + n2;

            int[] arr3 = new int[n3];

            while (p1 < n1 && p2 < n2)
            {
                if (arr1[p1] < arr2[p2])
                {
                    arr3[p3] = arr1[p1];
                    p1++;
                }
                else
                {
                    arr3[p3] = arr2[p2];
                    p2++;
                }
                p3++;
            }

            while (p1 < n1)
            {
                arr3[p3] = arr1[p1];
                p1++;
                p3++;
            }
            while (p2 < n2)
            {
                arr3[p3] = arr2[p2];
                p2++;
                p3++;
            }

            Console.WriteLine(string.Join(",", arr3));
        }
    }

    public class MergeTowArrayWithDiffrenceLenght
    {
        public static void Run(int[] result,int[] arr1, int[] arr2)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int n1 = arr1.Length;
            int n2 = arr2.Length;
            int n3 = n1 + n2;

            int[] arr3 = new int[n3];

            while (p1 < n1 && p2 < n2)
            {
                if (arr1[p1] < arr2[p2])
                {
                    result[p3] = arr1[p1];
                    p1++;

                }
                else
                {
                    result[p3] = arr2[p2];
                    p2++;

                }

                p3++;
            }

            while (p1 < n1)
            {
                result[p3] = arr1[p1];
                p3++;
                p1++;
            }
            while (p2 < n2)
            {
                result[p3] = arr2[p2];
                p2++;
                p3++;
            }

            Console.WriteLine(string.Join(",", result));
        }
    }


    public class Merge
    {
        public static void Run(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            Run(left);
            Run(right);
            MergeTowArrayWithDiffrenceLenght.Run(arr,left, right);

        }
    }
}