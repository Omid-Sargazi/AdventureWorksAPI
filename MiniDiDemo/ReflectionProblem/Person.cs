using System.Data.SqlTypes;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MiniDiDemo.ReflectionProblem
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private readonly int Id;
        public bool IsHere { get; set; }
        public string? Job { get; set; } = null;

        public Person() { }
        public Person(string name, int age, int id)
        {
            Age = age;
            Name = name;
            Id = id;
        }
    }

    public class ClientReflection
    {
        public static void Run()
        {
            var p1 = new Person { Name = "Omid", Age = 42,IsHere=true,Job=null };
            var p2 = new Person { Name = "Saeed", Age = 40,IsHere = false,Job="PHP"};
            RefCustome.Run(p2);

        }
    }


    public class RefCustome
    {
        public static void Run(object obj)
        {
            Dictionary<string, object> pairs = new();
            Type type = obj.GetType();

            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (!pairs.ContainsKey(prop.Name))
                {
                    pairs[prop.Name] = prop.GetValue(obj);
                }
            }

            string s = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");

            foreach (var p in pairs)
            {
                if (p.Value == null)
                {
                    stringBuilder.Append($"\"{p.Key}\"");
                    stringBuilder.Append(":");
                    stringBuilder.Append("null");
                    stringBuilder.Append(",");
                }
                else if (p.Value is string)
                {
                    stringBuilder.Append($"\"{p.Key}\"");
                    stringBuilder.Append(":");
                    stringBuilder.Append($"\"{p.Value}\"");
                    stringBuilder.Append(",");

                }

                else if (p.Value.GetType().IsValueType)
                {
                    stringBuilder.Append($"\"{p.Key}\"");
                    stringBuilder.Append(":");
                    stringBuilder.Append($"{p.Value}");
                    stringBuilder.Append(",");
                }
                else
                {

                }
                // Console.WriteLine($"{string.Join(",", pairs.Values)}");
            }
            if (stringBuilder.Length > 1 && stringBuilder[stringBuilder.Length - 1] == ',')
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
                    stringBuilder.Append("}");

            Console.WriteLine(stringBuilder);

            
        }
    }
}