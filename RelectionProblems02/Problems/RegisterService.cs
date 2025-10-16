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

    public class ClientRegister
    {
        public static void Run(Assembly assembly)
        {
            var allTypes = assembly.GetTypes();

            var registeredServices = allTypes.Where(t => t.GetCustomAttribute<AutoRegisterAttribute>() != null).ToList();


            foreach (var t in registeredServices)
            {
                var attr = t.GetCustomAttribute<AutoRegisterAttribute>();
                Console.WriteLine($"Found Service: {t.Name}(Lifetime={attr.LifeTime})");
            }
        }
    }


    public class AuthorizeAttribute : Attribute
    {
        public string Role { get; }
        public AuthorizeAttribute(string role)
        {
            Role = role;
        }
    }

    public class AdminActions
    {
        [Authorize("Admin")]
        public void DeleteUser(string username)
        {
            Console.WriteLine($"User '{username}' deleted.");
        }

        [Authorize("User")]
        public string ViewDashboard(string user)
        {
            return $"Dashboard viewed by {user}";
        }

        public void NoAccess()
        {
            Console.WriteLine("This method has no authorization attribute.");
        }
    }

    public class ClientAuthorization
    {
        public static void Run(Assembly assembly, string role)
        {
            var allTypes = assembly.GetTypes();

            foreach(var type in allTypes)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                foreach(var method in methods)
                {
                    var attr = method.GetCustomAttribute<AuthorizeAttribute>();

                    if (attr == null)
                    {
                        continue;
                    }

                    if (attr.Role != role)
                    {
                        Console.WriteLine($"⛔ Access denied for {method.Name} (Required: {attr.Role}, Current: {role})");
                        continue;
                    }

                    object? instance = null;
                    if(!method.IsStatic)
                    {
                        instance = Activator.CreateInstance(type);

                        var parameters = method.GetParameters();

                        object? result = null;

                        if (parameters.Length == 0)
                        {
                            result = method.Invoke(instance, null);
                        }

                        else
                        {
                            var args = parameters.Select(p => $"Sample_{p.Name}").ToArray();
                            result = method.Invoke(instance, args);
                        }

                        if(method.ReturnType!=typeof(void))
                        {
                            Console.WriteLine($"Result From {method.Name}:{result}");
                        }
                    }
                }
            }
        }
    }
    

}