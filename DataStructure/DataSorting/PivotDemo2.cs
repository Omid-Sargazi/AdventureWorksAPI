namespace DataStructure.DataSorting
{
    public class PivotDemo2
    {
        public static int Run(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            int pivot = arr[hi];
            int i = lo - 1;

            for (int j = 0; j <= hi; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }

            (arr[i + 1], arr[hi]) = (arr[hi], arr[i + 1]);
            Console.WriteLine(string.Join(",", arr) + $"  Pivot is:  {arr[hi]}");

            return i + 1;
        }
    }


    public class PivotDemo3
    {
        public static int Run(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length-1;
            int i = lo - 1;
            int pivot = arr[hi];


            for (int j = 0; j <= hi; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }

            (arr[i + 1], arr[hi]) = (arr[hi], arr[i + 1]);

            Console.WriteLine(string.Join(",", arr) + $"  pivot is : {pivot}");

            return i + 1;
        }
    }

}