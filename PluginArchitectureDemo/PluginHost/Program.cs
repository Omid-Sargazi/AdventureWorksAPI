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

         var assemblies = pluginFiles.Select(Assembly.LoadFrom).ToList();

         foreach (var assembly in assemblies)
        {
            Console.WriteLine($"📦 Loaded Assembly: {Path.GetFileName(assembly.Location)}");

            var registrars = assembly.GetTypes()
                .Where(t => typeof(IServiceRegistration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var registrarType in registrars)
            {
                var registrar = (IServiceRegistration)Activator.CreateInstance(registrarType)!;
                registrar.RegisterServices(services);
                Console.WriteLine($"🔧 Registered services from: {registrarType.Name}");
            }
        }

        var provider = services.BuildServiceProvider();

        foreach (var assembly in assemblies)
        {
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