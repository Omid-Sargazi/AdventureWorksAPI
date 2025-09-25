// See https://aka.ms/new-console-template for more information
using AlgorithemAndDataStructure.LeetCodeProblems;
using AlgorithemAndDataStructure.LinqInCSahrp;
using AlgorithemAndDataStructure.Polymorphisms;
using AlgorithemAndDataStructure.Trees;

Console.WriteLine("Hello, World!");

// // RunTreeNode.Run();

// // Student.RunStudent();
// int[] arr = new int[] { 2,7,11,15 };
// int[] arr2 = new int[] { 2,7,11,15, 3,7 };
// int target = 1;
// int target2 = 10;

// // var res = TwoSum.Run(arr, target);
// // Console.WriteLine($"{string.Join(",", res)}");
// // TwoSum.RunTwoSumWithDictionary(arr, target);
// // TwoSum.RunTwoSumWithDictionary2(arr2, target2);

// // TwoSum.FibonacciCache();/
// TwoSum.FibonacciIterativeWithCache();


// Dictionary<string, int> dict1 = new Dictionary<string, int>()
// {
//     ["Omid"] = 1,
//     ["Saeed"] = 2,
//     ["Vahid"] = 3
// };

// if (dict1.TryGetValue("Omid", out int value))
// {
//     Console.WriteLine(value);
// }
// else
// {
//     Console.WriteLine("Not Found");
// }


// new Thread(static () => Console.WriteLine($"Thread")).Start();
// ThreadPool.QueueUserWorkItem(_ => Console.WriteLine($"ThreadPool"));

// Task.Run(static () => Console.WriteLine("Task on ThreadPool"));

// async Task Demo()
// {
//     await Task.Delay(1000);
//     Console.WriteLine("Async/await");
// }

// await Demo();


// Task<int> t = Task.Run(() =>
// {
//     Thread.Sleep(1000);
//     return 42;
// });

// Console.WriteLine($"status: {t.Status}");
// int result = await t;
// Console.WriteLine($"Sttaus: {t.Status}, Result: {result}");

// Type student = typeof(Student);
// Console.WriteLine(student.Name);
// Console.WriteLine(student.FullName);
// Type stringType = typeof(string);

// Console.WriteLine(stringType.Name);
// Console.WriteLine(stringType.FullName);

// object obj = "Hello, World!";
// Type staticObject = typeof(string);
// Type dynamicObject = obj.GetType();

// RunPerson.Run();
LinqProblem.Run();