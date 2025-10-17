using HostPlugin;

namespace SamplePlugin
{
    public class HelloPlugin : IPlugin
    {
        public string Name => "Hello Plugin";
        public void Execute()
        {
            Console.WriteLine("👋 Hello from plugin!");
        }
    }

}