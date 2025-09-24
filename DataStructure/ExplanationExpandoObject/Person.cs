using System.Reflection;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace DataStructure.ExplanationExpandoObject
{
    public class Person
    {
        public string Name { get; set; } = "Omid";
        public void Say()
        {
            Console.WriteLine($"My name is {Name}");
        }

    }

    public class RefProblem
    {
        public static void Run()

        {
            var p = new Person();
            Type t = p.GetType();
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.Name);

            PropertyInfo pi = t.GetProperty("Name");
            if (pi != null)
            {
                Console.WriteLine(pi.GetValue(p));
                pi.SetValue(p, "Ali");
                Console.WriteLine(pi.GetValue(p));
            }

            MethodInfo mi = t.GetMethod("Say");
            if (mi != null)
            {
                mi.Invoke(p, null);
            }
        }
    }
  
}