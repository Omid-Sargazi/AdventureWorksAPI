using System.Globalization;
using System.Security.Cryptography;

namespace ProblemsInCSharp.Sortings
{
    public class SortProblems
    {
        public static void Bubble(int[] nums)
        {
            for (int start = nums.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                        swapped = true;
                    }

                }
                if (!swapped) break;
            }

            Console.WriteLine($"{string.Join(",", nums)}");
        }

        public static void Selection(int[] nums)
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

                if (i != minIndex)
                {
                    (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
                }
            }

            Console.WriteLine($"{string.Join(",", nums)}");
        }

        public static void Insertion(int[] nums)
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

            Console.WriteLine($"{string.Join(",", nums)}");
        }
        
        
    }
}