using Microsoft.Extensions.DependencyInjection;
using PluginHost;

namespace SamplePlugin
{
    public class GreetingService : IGreetingService
    {
        public void Greet()
        {
            Console.WriteLine("👋 Hello from GreetingService inside plugin!");
        }
    }

    public interface IGreetingService
    {
        void Greet();
    }

    public class GreetingPlugin : IPlugin
    {
        private readonly IGreetingService _greetingService;
        public GreetingPlugin(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public string Name => "Greeting Plugin";

        public void Execute()
        {
            Console.WriteLine($"🚀 Executing {Name}...");
            _greetingService.Greet();

        }
    }
    
    public class PluginServiceRegistration: IServiceRegistration
    {
         public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IGreetingService, GreetingService>();
        }
    }

}