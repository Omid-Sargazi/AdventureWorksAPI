namespace DataStructure.Sorting
{
    public class SortingInCSharp
    {
        public static void Bubble(int[] arr)
        {
            for (int start = arr.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
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

            Console.WriteLine(string.Join(",", arr));
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

                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
            }

            Console.WriteLine(string.Join(",", arr));
        }

        public static void Merge(int[] arr)
        {
            if (arr.Length <= 1) return;
            int mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];


            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);


            Merge(left);
            Merge(right);
            MergeTwoArray(arr, left, right);
        }

        public static void MergeTwoArray(int[] result, int[] left, int[] right)
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
                p2++;
                p3++;
            }

            Console.WriteLine(string.Join(",", result));
            Console.WriteLine("Endddd");
        }
    }
}