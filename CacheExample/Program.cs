// See https://aka.ms/new-console-template for more information
using CacheExample;
using CacheExample.ExpressionProblems;
using CacheExample.MultiThreading;

Console.WriteLine("Hello, World!");
// ValueTask<int> num = ValueTask.FromResult(100);

// Console.WriteLine(num);

// RunMyFile.Run();

// // await MyAsyncResource.RunMyAsyncResource();
// CancellationTokenSource cs = new CancellationTokenSource();
// var res = await ClientMultiThreading.GetFirstSuccessfulResultAsync(cs.Token);
// Console.WriteLine(res+" Result of task");

// try
// {
//     // var res = await ClientMultiThreadingAdvanced.GetFirstSuccessfulResultAsync(TimeSpan.FromSeconds(3));
//     //  Console.WriteLine($"\n🏁 Final Result: {res}");
//     var result = await ClientMultiThreadingAdvanced.GetDataWithRetryAndFallbackAsync();
//     Console.WriteLine($"\n🏁 Final Result: {result}");
// }
// catch (TimeoutException ex)
// {

//     Console.WriteLine($"❌ All sources failed: {ex.Message}");
// }


ExpressionDemo.Run();
var res = ExpressionDemo.BuildExpression<User>("Age", "<", 30);
Console.WriteLine(res);

var compile = res.Compile();
Console.WriteLine(compile(new User { Age = 40 }));
Console.WriteLine(compile(new User { Age = 29 }));