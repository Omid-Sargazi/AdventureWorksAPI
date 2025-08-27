namespace DataStructure.DataSorting;

public class Power
{
    public static int Run(int a, int b)
    {
        if (b == 0) return 1;
        if (b == 1) return a;

        if (b % 2 == 0)
        {
            int half = Run(a, b / 2);
            return half * half;
        }

        else
        {
            return Run(a, b - 1);
        }
    }
}