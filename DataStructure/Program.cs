// See https://aka.ms/new-console-template for more information
using DataStructure.SortData;
using DataStructure.Sorting;
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

int[] arr7 = new int[] { 7, 8, 7, 1, 0, 0, 1, 2, -7, -9, -80, -70,0,0,0,-7,7,9 };
// Merge.Run(arr7);


// MergeSort.Run(arr7);

// SortingInCSharp.Bubble(arr7);
// SortingInCSharp.Selection(arr7);

// SortingInCSharp.Merge(arr7);

// Console.WriteLine(StringExample.Run("Omidd"));
// Console.WriteLine(StringExample.RunTwoFor("Omid"));

// ReverseStringTwoPointers.Reverse("omid");
Bubble.Run(arr7);