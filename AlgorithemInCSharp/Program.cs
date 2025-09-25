using AlgorithemInCSharp.LeetCodeProblems;

namespace AlgorithemInCSharp;
public class Program
{
    public static void Main(string[] args)
    {
        //AlgorithemAndDataStructure.Trees.RunTreeNode.Run();
        //AlgorithemInCSharp.Delegates.Delegatess.Run();
        Console.WriteLine("Hello, World!");

        // SimpleResource.RunSimpleResource.Run();

        int[] arr1 = new int[] { };
        int[] arr2 = new int[] { 1 };
        int[] arr3 = new int[] { 1, 2 };
        int[] arr4 = new int[] { 1, 2,1,2,3,3,4 };
        // Console.WriteLine(Problem1.ContainsDuplicate3(arr2));

        Console.WriteLine($"{Problem2.SingleNumber(arr4)}");
    }
}