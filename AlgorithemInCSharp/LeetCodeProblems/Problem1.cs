namespace AlgorithemInCSharp.LeetCodeProblems
{
    public class Problem1
    {
        public static bool ContainsDuplicate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[j + 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ContainsDuplicate2(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}