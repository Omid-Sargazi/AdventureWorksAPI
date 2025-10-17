namespace HostPlugin
{
    public interface IPlugin
    {
        public string Name { get; }
        void Execute();
    }
}