namespace DataStructure.ExplanationExpandoObject
{
    public class Container
    {
        private Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            _mappings[typeof(TInterface)] = typeof(TImplementation);
        }

        public T Resolve<T>()
        {
            Type implementationType = _mappings[typeof(T)];
            return (T)Activator.CreateInstance(implementationType);
        }
    }
}