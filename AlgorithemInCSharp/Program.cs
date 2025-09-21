// See https://aka.ms/new-console-template for more information
using AlgorithemInCSharp.Sorting;

Console.WriteLine("Hello, World!");
int[] arr1 = new int[] { 5, 4, 3, 2, 1,-100,-200,800,78,0,0 };
// SortingsInCSharp.Buuble(arr1);
// SortingsInCSharp.SelectionSort(arr1);
// SortingsInCSharp.InsertionSort(arr1);
// SortingsInCSharp.MeregeSort(arr1);
SortingsInCSharp.QuickSort(arr1, 0, arr1.Length - 1);