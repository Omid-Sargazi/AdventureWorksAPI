namespace DataStructure.Sorting
{
    public class SortingInCSharp
    {
        public static void Bubble(int[] arr)
        {
            for (int start = arr.Length-1; start >= 0; start--)
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

        }

        public static void Merge(int[] arr)
        {

        }
    }
}