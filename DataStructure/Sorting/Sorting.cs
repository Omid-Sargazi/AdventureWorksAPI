namespace DataStructure.Sorting
{
    public class BubbleSort
    {
        public static void Run(int[] arr)
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
}