using System.Globalization;

namespace DataStructure.SortData
{
    public class Bubble
    {
        public static void Run(int[] nums)
        {
            for (int start = nums.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j <= start - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }

            Console.WriteLine(string.Join(",", nums));
        }
    }

    public class SelectionInCSahrp
    {
        public static void Run(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }
                (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
            }

            Console.WriteLine(string.Join(",", nums));
        }
    }

    public class InsertionInCSharp
    {
        public static void Run(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];
                int j = i - 1;

                while (j >= 0 && nums[j] > current)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }

                nums[j + 1] = current;
            }

            Console.WriteLine(string.Join(",", nums) + "  Insertion");
        }
    }


    public class MergeSortInCSharp
    {

        public static void Run(int[] arr)
        {
            if (arr.Length <= 1) return;
            int n = arr.Length;
            Console.WriteLine($"n:{n},  n/2:{n / 2}  n/2-n:{n - (n / 2)}");
            int[] left = new int[n / 2];
            int[] right = new int[arr.Length - (n / 2)];

            for (int i = 0; i < n / 2; i++)
            {
                left[i] = arr[i];
            }

            for (int j = n / 2; j <= arr.Length - 1; j++)
            {
                right[j - (n / 2)] = arr[j];
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