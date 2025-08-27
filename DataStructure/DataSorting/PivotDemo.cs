namespace DataStructure.DataSorting
{
    public class PivotDemo
    {
        public static int Run(int[] arr)
        {
            int pivot = arr[arr.Length - 1];
            int i = -1;

            for (int j = 0; j < arr.Length-1; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[arr.Length - 1]) = (arr[arr.Length - 1], arr[i + 1]);
            Console.WriteLine(string.Join(",",arr));
            return i + 1;
        }
    }
}