namespace DataStructure.DataSorting
{
    public class QuickSorting
    {
        public static int[] Run(int[] arr)
        {
            if (arr.Length < 2)
                return arr;

            int pivot = arr[0];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < pivot)
                    less.Add(arr[i]);

                else
                    greater.Add(arr[i]);
            }

            var sortedLess = Run(less.ToArray());
            var sortedGreater = Run(greater.ToArray());

            List<int> result = new List<int>();
            result.AddRange(sortedLess);
            result.Add(pivot);
            result.AddRange(sortedGreater);

            return [.. result];
        }

       
    }
}