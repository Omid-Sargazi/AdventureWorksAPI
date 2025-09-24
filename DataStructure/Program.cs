// See https://aka.ms/new-console-template for more information
using DataStructure;
using DataStructure.DataSorting;
using DataStructure.ExplanationExpandoObject;
using DataStructure.IEnumerables;
using DataStructure.SimpleResource;
using DataStructure.SortData;
using DataStructure.Sorting;
using DataStructure.SortingAlgorithems;
using DataStructure.SortingInCSharp;
using DataStructure.SortingWithCSharp;

Console.WriteLine("Hello, World!!!!");
// int[] arr = new int[] { 70, -70, 1, 4, 50, 78, 87, 88, 99 };
// int[] arr2 = new int[] {0,0,0 };
// // BubbleSort.Run(arr2);
// // SelectionSort.Run(arr);
// // InsertionSort.Run(arr);

// int[] arr3 = new int[] { 1, 2, 3, 4, 5,7,7,7 };
// int[] arr4 = new int[] { -80,-70, -69, -68,7,7,7, 100, 110, 120,1300 };
// int[] arr5 = new int[] { -1,0 };
// int[] arr6 = new int[] { 0, 0 };

// int[] arr7 = new int[] { 7, 8, 7, 1, 0, 0, 1, 2, -7, -9, -80, -70,0,0,0,-7,7 };
// // Merge.Run(arr7);


// // MergeSort.Run(arr7);

// // SortingInCSharp.Bubble(arr7);
// // SortingInCSharp.Selection(arr7);

// // SortingInCSharp.Merge(arr7);

// // Console.WriteLine(StringExample.Run("Omidd"));
// // Console.WriteLine(StringExample.RunTwoFor("Omid"));

// // ReverseStringTwoPointers.Reverse("omid");
// // Bubble.Run(arr7);

// // SelectionInCSahrp.Run(arr7);

// // InsertionInCSharp.Run(arr7);
// int[] arr8 = new int[] { 0, 10, -5 };
// int[] arr9 = {2, -4, 3, -1, 2, -4, 3};

// // MergeSortInCSharp.Run(arr7);
// // BubbleSorting.Run(arr7);
// // SelectionSortt.Run(arr7);
// // InsertionSorting.Run(arr7);
// // MergeSortingg.Run(arr7);

// // var result = QuickSorting.Run(arr7);
// // 
// // Console.WriteLine(string.Join(",", result));


// // Console.WriteLine(MaximumSubarraySum.Run(arr9,0,arr9.Length-1));
// // Console.WriteLine(PivotDemo.Run(arr8));

// int[] arr10 = new int[] { 10, 80, 30, 90, 40, 50, 70 };

// // Console.WriteLine(PivotDemo2.Run(arr7));
// // Console.WriteLine(PivotDemo3.Run(arr10));

// // SortAlgorithem.Bubble(arr10);
// // SortAlgorithem.SelectionSort(arr7);
// // SortAlgorithem.InsertionSort(arr7);
// // SortAlgorithem.MergeSorting(arr7);
// // BubbleSorttt.Bubble(arr7);
// // BubbleSorttt.Selection(arr7);
// // BubbleSorttt.InsertionSort(arr7);
// // MergingSort.Run(arr7);

// int[] arr11 = new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50 };
// string[] arr12 = new string[] { "o","m","i","d" };
// int[] arr20 = new int[] {};
// int[] arr30 = new int[] { 5 };

// var people = new[]
// {
//     new {id=1, Name = "Ali", Age = 25 },
//     new { id=2, Name = "Reza", Age = 30 },
//     new { id=3, Name = "Ali", Age = 25 },
//     new { id=4, Name = "Reza", Age = 25 },
//     new { id=5, Name = "Maryam", Age = 30 }
// };

// var orders = new[]
// {
//     new { PersonId = 1, Product = "Book" },
//     new { PersonId = 2, Product = "Pen" }
// };

// //========================= Single===============
// Console.WriteLine($"{arr30.Single()}"+" Single");
// Console.WriteLine($"{arr30.SingleOrDefault(x=>x>10)}"+" Single");
// // Console.WriteLine($"{arr30.Single(x=>x>10)}"+" Single");


// //========================= Last ===============

// Console.WriteLine($"{arr30.Last(x=>x>4)}"+" Last");
// Console.WriteLine($"{arr11.Last()}"+" Last");
// Console.WriteLine($"{arr20.LastOrDefault()}" + " Last");

// //========================First/FirstOrDefault===================

// Console.WriteLine($"{arr20.FirstOrDefault()}" + " First");
// Console.WriteLine($"{arr11.FirstOrDefault()}" + " First");
// //=========================

// //======================Where==================
// Console.WriteLine($"{arr11.Where(x => x > 20).Skip(2).Last()}" + " Where and first");

// var filteredList = arr.Where(x => x > 20).ToList();
// filteredList.ForEach(item => Console.WriteLine(item));
// Console.WriteLine("Where and Foreach");

// var orderBy = arr20.OrderBy(x => x);
// var orderBydesc = arr7.OrderByDescending(x => x);
// Console.WriteLine($"{string.Join(",",orderBy)}"+" Order By");
// Console.WriteLine($"{string.Join(",", orderBydesc)}" + " Order By");


// var byAge = people.OrderBy(people => people.Age);
// Console.WriteLine($"{string.Join(",", byAge)}" + " by Age");

// var byName = people.OrderByDescending(people => people.Name).ThenByDescending(people=>people.Age);
// Console.WriteLine($"{string.Join(",", byName)}" + " by Name");

// var grouped = people.GroupBy(p => p.Name);
// Console.WriteLine(string.Join(",", grouped) + " Grouped");

// foreach (var g in grouped)
// {
//     Console.WriteLine($"Name Group: {g.Key}");
//     foreach (var item in g)
//     {
//         Console.WriteLine($"-{item.Name},{item.Age}");
//     }
// }


// var joined = people.GroupJoin(orders,
//     p => p.id,
//     o => o.PersonId,
//     (p, o) => new
//     {
//         p.Name,
//         Products = orders.Select(o=>o.Product).DefaultIfEmpty("No Order")
//     }
// );

// foreach (var item in joined)
// {
//     Console.WriteLine($"{item.Name}:{string.Join(",",item.Products)}");
// }

// ClientMaxPriorityQueue.Run();

// RunSimpleResource.Run();


// byte[] bigData = new byte[1_000_000_000];
// byte[] smallCopy = new byte[100];
// Array.Copy(bigData, 50, smallCopy, 0, 100);
// Console.WriteLine("Small Copy Length: " + smallCopy.Length);
// foreach (var item in smallCopy)
// {
//     // Console.Write(item + ",");
// }


// Span<byte> smartView = bigData.AsSpan(50, 100);
// Console.WriteLine("\nSmart View Length: " + smartView.Length);
// foreach (var item in smartView)
// {
//     Console.Write(item + ",");
// }


// Student.RunStudent();

// ExplanationExpandoObject.Run();
// ExplanationExpandoObject.Run2();

RefProblem.Run();