namespace PluginHost
{
    public interface IPlugin
    {
        string Name { get; }
        void Execute();
    }
}