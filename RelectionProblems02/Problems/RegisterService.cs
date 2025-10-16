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

    public class  RunOnStartupAttribute: Attribute
    {
        
    }

    public class StartupTasks
    {
        [RunOnStartup]
        public void InitializeDatabase() => Console.WriteLine($"Database initilized");
        [RunOnStartup]
        public void WarmupCache() => Console.WriteLine("Cache warmed up.");
        public void SendEmail() => Console.WriteLine("This should not run automatically.");
    }

    public class ClienStartup
    {
        public static void Run(Assembly assembly)
        {
            var allTypes = assembly.GetTypes();
           
           foreach(var type in allTypes)
             {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                foreach(var method in methods)
                {
                    var attr = method.GetCustomAttribute<RunOnStartupAttribute>();
                    if(attr!=null)
                    {
                        object? instance = null;

                        if (!method.IsStatic)
                        {
                            instance = Activator.CreateInstance(type);
                        }

                        method.Invoke(instance, null);
                    }
                }
            }
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