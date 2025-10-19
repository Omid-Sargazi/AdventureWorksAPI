using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace MainPlugin.MainPlugin2
{
    public class MainPlugin2
    {
        public static void Run()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            var assemblyPath = config["PluginSettings2:AssemblyPath"];
            var className = config["PluginSettings2:ClassName"];
            var methodName = config["PluginSettings2:MethodName"];

            Console.WriteLine($"Assembly:{assemblyPath}");
            Console.WriteLine($"Class:{className}");
            Console.WriteLine($"Method:{methodName}");

            string pluginFolder = Path.Combine(Directory.GetCurrentDirectory(), "plugins");
            if (!Directory.Exists(pluginFolder))
                Directory.CreateDirectory(pluginFolder);

            var pluginFiles = Directory.GetFiles(pluginFolder, "*.dll");

            foreach(var file in pluginFiles)
            {
                Console.WriteLine($"Loading...{Path.GetFileName(file)}");

                Assembly assembly = Assembly.LoadFrom(file);
                var pluginTypes = assembly.GetTypes().Where(t => t.FullName == className && !t.IsInterface && !t.IsAbstract).ToList();

                foreach(var type in pluginTypes)
                {
                    Console.WriteLine($"Found type: {type}");
                    var instance = Activator.CreateInstance(type);
                    Console.WriteLine($"Found type: {instance}");

                    var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                    if (method == null)
                    {
                        Console.WriteLine($"❌ Method {methodName} not found in {type.FullName}");
                        continue;
                    }
                    
                    Console.WriteLine(method);
                    method.Invoke(null, null);

                }
            }
        }
    }
}