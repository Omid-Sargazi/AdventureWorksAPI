namespace AlgorithemAndDataStructure.LeetCodeProblems
{
    public class BestTimeBuySell_Stock
    {
        public static int Run(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;

            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (var item in prices)
            {
                if (item < minPrice)
                {
                    minPrice = item;
                }
                else
                {
                    int profit = item - minPrice;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit;
        }
    }
}