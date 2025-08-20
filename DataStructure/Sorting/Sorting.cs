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
                for (int j = i+1; j < arr.Length; j++)
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
}