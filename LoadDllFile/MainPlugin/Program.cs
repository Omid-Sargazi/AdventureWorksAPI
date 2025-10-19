using System.Reflection;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        var assemblyPath = config["PluginSettings:AssemblyPath"];
        var className = config["PluginSettings:ClassName"];
        var methodName = config["PluginSettings:Methodname"];

        Console.WriteLine($"Assembly:{assemblyPath}");
        Console.WriteLine($"Class:{className}");
        Console.WriteLine($"method:{methodName}");
    }
}