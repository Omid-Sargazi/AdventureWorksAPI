// See https://aka.ms/new-console-template for more information
// using Sorting.KindOfSorting;
using Sorting.KindOfSorting;
using Sorting.SortingAlgorithem;
using Sorting.SortingAlgorithems;
using Sorting.Trees;

Console.WriteLine("Hello, World!");
int[] arr1 = new int[] { 1, 2, 3, -10, 10, -100, 100, 40, 41, 52, 44 };
int[] arr2 = new int[] { 1, 2, 3 };

// Heapify.Run(arr1);

// Sortingg.MergeSort(arr1);
// HeapifySorting.Run(arr2);
// HeapifySortingg.Run(arr1);
// HeapSortArray.Run(arr1);

// var pq = new MinPriorityQueuee(arr1);
// HeapifySorting.Run(arr1);
// Console.WriteLine(pq);

// Sortings.Selection(arr1);
// Sortings.Insertion(arr1);
// Sortings.RunQuickSort(arr1);
// Sortings.RunQuickSort2(arr1);

string Describe(object o) => o switch
{
    null => "null",
    int i and >= 0 => $"non-navigate int{i}",
    string { Length: > 0 } s => $"string:{s}",
    _ => "something else"
};

Console.WriteLine(Describe(10));

// RunTreeNode.Run();
RunUniversityTree.Run();