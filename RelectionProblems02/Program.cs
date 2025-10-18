// using System.Reflection;
// using RelectionProblems02.Problems;

// var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddOpenApi();

// // builder.Services.AddRepositories(Assembly.GetExecutingAssembly());

// // ClientRegister.Run(Assembly.GetExecutingAssembly());
// // ClienStartup.Run(Assembly.GetExecutingAssembly());

// ClientAuthorization.Run(Assembly.GetExecutingAssembly(), "User");
// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }


// app.UseHttpsRedirection();



// app.Run();

using RelectionProblems02.ReflectionProblems;

Console.WriteLine("hellooooo");
Person2 p1 = new Person2();
var res = RefClient.Run(p1);
Console.WriteLine(res);