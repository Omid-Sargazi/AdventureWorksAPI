// See https://aka.ms/new-console-template for more information
using ProblemsInCSharp.Automapper;
using ProblemsInCSharp.SerializedAndDeserialized;
using ProblemsInCSharp.Sortings;

Console.WriteLine("Hello, World!");
int[] nums = new int[] { 7, 8, 1, 2, 0, 12, 13, 45, -45 };
int[] nums1 = new int[] { 1, 2, 3 };

// SortProblems.Bubble(nums);

// SortProblems.Selection(nums);
// SortProblems.Insertion(nums);

// CLientList.Run();
// SortProblems.QuickSort(nums, 0, nums.Length-1);

// Client.Run();

ClientMapper.Run();
