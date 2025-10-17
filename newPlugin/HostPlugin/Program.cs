using System.Reflection;
using HostPlugin;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("🔍 Plugin Loader Started...");

        string pluginFolder = Path.Combine(Directory.GetCurrentDirectory(), "plugins");
        if (!Directory.Exists(pluginFolder))
            Directory.CreateDirectory(pluginFolder);

        var pluginFiles = Directory.GetFiles(pluginFolder, "*.dll");

        foreach (var file in pluginFiles)
        {
            Console.WriteLine($"📦 Loading {Path.GetFileName(file)} ...");

            Assembly assembly = Assembly.LoadFile(file);

            var pluginTypes = assembly.GetTypes()
            .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in pluginTypes)
            {
                var plugin = (IPlugin)Activator.CreateInstance(type);
                Console.WriteLine($"✅ Plugin Loaded: {plugin.Name}");
                plugin.Execute();
            }
        }
        
        Console.WriteLine("✅ All plugins executed successfully!");
    }
}