// // See https://aka.ms/new-console-template for more information
// using DesignPatterns.StructuralDesignPattern;
// using DesignPatterns.StructuralDesignPattern2;

// Console.WriteLine("Hello, World! from Design Pattern");
// // ClientComponent.Run();
// // ClienEmployee.Run();
// // ClientEmployeeLeaf.Run();

// SimpleFile file1 = new SimpleFile("f1.txt", 20);
// SimpleFile file2 = new SimpleFile("f2.txt", 30);
// SimpleFile img1 = new SimpleFile("i1.img", 300);
// SimpleFile img2 = new SimpleFile("i2.img", 200);

// Folder folder1 = new Folder("texts");
// Folder folder2 = new Folder("images");

// Folder Mainfolder = new Folder("Main");
// Folder Rootfolder = new Folder("Root");

// folder1.AddComponent(file1);
// folder1.AddComponent(file2);

// folder2.AddComponent(img1);
// folder2.AddComponent(img2);
// Mainfolder.AddComponent(folder1);
// Mainfolder.AddComponent(folder2);
// Rootfolder.AddComponent(Mainfolder);
// Rootfolder.Display();
// Console.WriteLine(Rootfolder.GetSize());


// ClientReport.Run();


// using DesignPatterns.Trees;

// ClientBST.Run();
// Console.WriteLine("LinkedListssss");
// CLientLinkedList.Run();

// using DesignPatterns.Trees;

// BSTClient.Run();

// using DesignPatterns.Trees;

// LinkedListClinet.Run();
using DesignPatterns.ExpressionTree;
using DesignPatterns.PaymentNotificationSystem;
using DesignPatterns.ReadParallel;
Console.WriteLine("Hellooooo");

// var expre = ExpressionTreeProblem1.BuildExpression<Order>("Id", ">", 30);

// var expr1 = ExpressionTreeProblem1.BuildExpression<Order>("Id", ">=", 12);
// var expr2 = ExpressionTreeProblem1.BuildExpression<Order>("Name", "==", "Omid");

// var compile = expre.Compile();

// Console.WriteLine(compile(new Order{Id=50,Name="Book"}));
// Console.WriteLine(compile(new Order{Id=29,Name="Book"}));


// ClientPayment.Run("Hiii From Notification");

ReadParallelFromFiles.Run();