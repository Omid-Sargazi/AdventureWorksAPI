namespace DataStructure.SortingWithCSharp
{
    public class AdvancedSorting
    {
        public static void Run(int[] result, int[] arr1, int[] arr2)
        {
            int p1 = 0; int p2 = 0; int p3 = 0;

            int n1 = arr1.Length;
            int n2 = arr2.Length;



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
                p1++;
                p3++;
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

    public class MergeSort
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
            AdvancedSorting.Run(arr, left, right);
        }
    }

    
}