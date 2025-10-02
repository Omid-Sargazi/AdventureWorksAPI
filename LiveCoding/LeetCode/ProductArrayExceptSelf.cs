using System.Linq.Expressions;

namespace LiveCoding.LeetCode
{
    public class ProductArrayExceptSelf
    {
        public static void Run(int[] nums)
        {
            Console.WriteLine($"{string.Join(",",nums)}");

            int n = nums.Length;
            int[] res = new int[n];


            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = nums[i - 1] * res[i-1];
            }

            int rightProduct = 1;
            for (int i = n; i >= 0; i--)
            {
                res[i] = res[i] * rightProduct;
                rightProduct =  nums[i] * rightProduct;
            }


            Console.WriteLine($"{string.Join(",",res)}");
        }
    }
}