using System.Data.Common;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PluginHost;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("🔍 Starting Plugin Loader with DI...");

        var services = new ServiceCollection();
        var pluginFolder = Path.Combine(Directory.GetCurrentDirectory(), "plugins");

        if (!Directory.Exists(pluginFolder))
        {
            Directory.CreateDirectory(pluginFolder);
        }

        var pluginFiles = Directory.GetFiles(pluginFolder, "*.dll");

        foreach (var file in pluginFiles)
        {
            Assembly assembly = Assembly.LoadFile(file);
            Console.WriteLine($"📦 Loaded Assembly: {Path.GetFileName(file)}");

            var registrars = assembly.GetTypes()
            .Where(t => typeof(IServiceRegistration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var registrarType in registrars)
            {
                var register = (IServiceRegistration)Activator.CreateInstance(registrarType);
                register.RegisterServices(services);
                Console.WriteLine($"🔧 Registered services from: {registrarType.Name}");
            }
        }

        var provider = services.BuildServiceProvider();

        foreach (var file in pluginFiles)
        {
            Assembly assembly = Assembly.LoadFrom(file);

            var pluginTypes = assembly.GetTypes()
                .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in pluginTypes)
            {
                var plugin = (IPlugin)ActivatorUtilities.CreateInstance(provider, type);
                Console.WriteLine($"✅ Loaded Plugin: {plugin.Name}");
                plugin.Execute();
            }
        }
        
        Console.WriteLine("✅ All plugins loaded and executed with DI!");
    }
}