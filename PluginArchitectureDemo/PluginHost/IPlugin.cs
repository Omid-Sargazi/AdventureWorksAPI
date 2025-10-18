namespace PluginHost;
public interface IPlugin
{
    public string Name { get; }
    public void Execute();
}