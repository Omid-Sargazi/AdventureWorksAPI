// See https://aka.ms/new-console-template for more information
using AlgorithemAndDataStructure.LeetCodeProblems;
using AlgorithemAndDataStructure.LinqInCSahrp;
using AlgorithemAndDataStructure.Trees;

Console.WriteLine("Hello, World!");

// RunTreeNode.Run();

// Student.RunStudent();
int[] arr = new int[] { 2,7,11,15 };
int[] arr2 = new int[] { 2,7,11,15, 3,7 };
int target = 1;
int target2 = 10;

// var res = TwoSum.Run(arr, target);
// Console.WriteLine($"{string.Join(",", res)}");
// TwoSum.RunTwoSumWithDictionary(arr, target);
TwoSum.RunTwoSumWithDictionary2(arr2, target2);