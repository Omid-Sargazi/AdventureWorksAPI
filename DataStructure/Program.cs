// See https://aka.ms/new-console-template for more information
using DataStructure.DataSorting;
using DataStructure.SortData;
using DataStructure.Sorting;
using DataStructure.SortingAlgorithems;
using DataStructure.SortingInCSharp;
using DataStructure.SortingWithCSharp;

Console.WriteLine("Hello, World!!!!");
int[] arr = new int[] { 70, -70, 1, 4, 50, 78, 87, 88, 99 };
int[] arr2 = new int[] {0,0,0 };
// BubbleSort.Run(arr2);
// SelectionSort.Run(arr);
// InsertionSort.Run(arr);

int[] arr3 = new int[] { 1, 2, 3, 4, 5,7,7,7 };
int[] arr4 = new int[] { -80,-70, -69, -68,7,7,7, 100, 110, 120,1300 };
int[] arr5 = new int[] { -1,0 };
int[] arr6 = new int[] { 0, 0 };

int[] arr7 = new int[] { 7, 8, 7, 1, 0, 0, 1, 2, -7, -9, -80, -70,0,0,0,-7,7 };
// Merge.Run(arr7);


// MergeSort.Run(arr7);

// SortingInCSharp.Bubble(arr7);
// SortingInCSharp.Selection(arr7);

// SortingInCSharp.Merge(arr7);

// Console.WriteLine(StringExample.Run("Omidd"));
// Console.WriteLine(StringExample.RunTwoFor("Omid"));

// ReverseStringTwoPointers.Reverse("omid");
// Bubble.Run(arr7);

// SelectionInCSahrp.Run(arr7);

// InsertionInCSharp.Run(arr7);
int[] arr8 = new int[] { 0, 10, -5 };
int[] arr9 = {2, -4, 3, -1, 2, -4, 3};

// MergeSortInCSharp.Run(arr7);
// BubbleSorting.Run(arr7);
// SelectionSortt.Run(arr7);
// InsertionSorting.Run(arr7);
// MergeSortingg.Run(arr7);

// var result = QuickSorting.Run(arr7);
// 
// Console.WriteLine(string.Join(",", result));


// Console.WriteLine(MaximumSubarraySum.Run(arr9,0,arr9.Length-1));
// Console.WriteLine(PivotDemo.Run(arr8));

int[] arr10 = new int[] { 10, 80, 30, 90, 40, 50, 70 };

// Console.WriteLine(PivotDemo2.Run(arr7));
// Console.WriteLine(PivotDemo3.Run(arr10));

// SortAlgorithem.Bubble(arr10);
// SortAlgorithem.SelectionSort(arr7);
// SortAlgorithem.InsertionSort(arr7);
// SortAlgorithem.MergeSorting(arr7);
// BubbleSorttt.Bubble(arr7);
// BubbleSorttt.Selection(arr7);
// BubbleSorttt.InsertionSort(arr7);
// MergingSort.Run(arr7);

int[] arr11 = new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50 };
string[] arr12 = new string[] { "o","m","i","d" };
int[] arr20 = new int[] {};
int[] arr30 = new int[] { 5 };

Console.WriteLine($"{arr20.Any()}: Any"); 
Console.WriteLine($"{arr20.All(x=>x>4)}: All"); 
Console.WriteLine($"{arr20.All(x=>x>10)}: All"); 
Console.WriteLine($"{arr20.Any()}: Any");
Console.WriteLine($"{arr11.Any(x => x < 0)}: Any"); 

//==================================
Console.WriteLine($"{arr12.ElementAtOrDefault(20)}: ElementAt");//throw an exception ArgumentOutOfRangeException
Console.WriteLine($"{arr11.ElementAt(2)}: ElementAt"); 

//==================================

//==================================
Console.WriteLine($"{arr11.Single(x=>x>40)}: Single"); 
//==================================


