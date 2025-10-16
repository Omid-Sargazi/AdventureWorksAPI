using System.Reflection;

namespace RelectionProblems02.Problems
{
    [AutoRegister("Scoped")]
    public class UserService { }
    [AutoRegister("Transient")]
    public class OrderService { }
    public class ProductService { }

    [AttributeUsage(AttributeTargets.Class)]
    public class AutoRegisterAttribute : Attribute
    {
        public string LifeTime { get; }
        public AutoRegisterAttribute(string lifeTime)
        {
            LifeTime = lifeTime;
        }
    }

    public  class ClientRegister
    {
        public static void Run(Assembly assembly)
        {
            var allTypes = assembly.GetTypes();

            var registeredServices = allTypes.Where(t => t.GetCustomAttribute<AutoRegisterAttribute>() != null).ToList();


            foreach(var t in registeredServices)
            {
                var attr = t.GetCustomAttribute<AutoRegisterAttribute>();
                Console.WriteLine($"Found Service: {t.Name}(Lifetime={attr.LifeTime})");    
            }           
        }
    }
}