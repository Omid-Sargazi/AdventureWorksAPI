namespace DataStructure.DataSorting
{
    public class BubbleSorting
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
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }

            Console.WriteLine(string.Join(",", arr));
        }
    }

    public class SelectionSortt
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

                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
            }

            Console.WriteLine(string.Join(",", arr));
        }
    }


    public class InsertionSorting
    {
        public static void Run(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int current = arr[i];

                while (j >= 0 && arr[j] < current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }


            Console.WriteLine(string.Join(",", arr));
        }
    }

    public class MergeSortingg
    {
        public static void Run(int[] arr)
        {

            if (arr.Length <= 1) return;
            int n = arr.Length;
            int[] left = new int[arr.Length / 2];
            int[] right = new int[arr.Length - (arr.Length) / 2];

            for (int i = 0; i < n / 2; i++)
            {
                left[i] = arr[i];
            }

            for (int j = n / 2; j < arr.Length; j++)
            {
                right[(j) - (n / 2)] = arr[j];
            }

            Console.WriteLine(string.Join(",", left) + "Left");
            Console.WriteLine(string.Join(",", right) + "right");

            Run(left);
            Run(right);
            Merge(arr, left, right);
        }

        public static void Merge(int[] result, int[] left, int[] right)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int n1 = left.Length;
            int n2 = right.Length;

            while (p1 < n1 && p2 < n2)
            {
                if (left[p1] > right[p2])
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
                p3++;
                p1++;
            }

            while (p2 < n2)
            {
                result[p3] = right[p2];
                p2++;
                p3++;
            }


            Console.WriteLine(string.Join(",", result));
        }
    }
}