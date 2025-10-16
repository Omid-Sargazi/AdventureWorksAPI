// See https://aka.ms/new-console-template for more information
using CacheExample;
using CacheExample.MultiThreading;

Console.WriteLine("Hello, World!");
// ValueTask<int> num = ValueTask.FromResult(100);

// Console.WriteLine(num);

// RunMyFile.Run();

// // await MyAsyncResource.RunMyAsyncResource();
// CancellationTokenSource cs = new CancellationTokenSource();
// var res = await ClientMultiThreading.GetFirstSuccessfulResultAsync(cs.Token);
// Console.WriteLine(res+" Result of task");

try
{
    var res = await ClientMultiThreadingAdvanced.GetFirstSuccessfulResultAsync(TimeSpan.FromSeconds(3));
     Console.WriteLine($"\n🏁 Final Result: {res}");
}
catch (TimeoutException ex)
{
    
     Console.WriteLine(ex.Message);
}