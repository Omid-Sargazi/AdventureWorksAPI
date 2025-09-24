// See https://aka.ms/new-console-template for more information
using AlgorithemAndDataStructure.LeetCodeProblems;
using AlgorithemAndDataStructure.LinqInCSahrp;
using AlgorithemAndDataStructure.Trees;

Console.WriteLine("Hello, World!");

// RunTreeNode.Run();

// Student.RunStudent();
int[] arr = new int[] { 2,7,11,15 };
int target = 9;

var res = TwoSum.Run(arr, target);
Console.WriteLine($"{string.Join(",",res)}");