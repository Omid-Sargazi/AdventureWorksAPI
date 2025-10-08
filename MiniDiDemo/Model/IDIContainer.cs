namespace MiniDiDemo.Model
{
    public enum ServiceLifeTime
    {
        Transient,
        Scoped,
        Singleton,
    }
    public interface IDIContainer
    {
        
        void Register<TInterface, TImplementation>(ServiceLifeTime lifeTime);
        T Resolve<T>();
    }

    public class DIContainer : IDIContainer
    {
        private Dictionary<Type, ServiceDescriptor> _descriptors = new();
        public void Register<TInterface, TImplementation>(ServiceLifeTime lifeTime)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceDescriptor
    {

        public Type ServiceType { get; set; }
        public Type ImplementationType { get; set; }
        public ServiceLifeTime LifeTime { get; set; }
        public object Instance { get; set; }
    }

}