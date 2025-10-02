using System.Reflection;
using System.Text;

namespace LiveCoding.Reflections
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class JsonSerialize
    {
        protected static Dictionary<string, object> jsonInformation = new Dictionary<string, object>();
        public static void Serialize(object obj)
        {
            var sb = new StringBuilder();
            sb.Append("{");


            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            int count = 0;

            foreach (var prop in properties)
            {
                sb.Append($"\"{prop.Name}\"");
                sb.Append(":");
                if (prop.PropertyType == typeof(int))
                {

                    sb.Append(prop.GetValue(obj));
                }
                else
                {
                    sb.Append($"\"{prop.GetValue(obj)}\"");
                }

                if (count < properties.Length - 1)
                {
                    sb.Append(",");
                }

                count++;

            }
            sb.Append("}");
            Console.WriteLine(sb);
        }

        public static string Serialize2(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            var keyValue = new List<string>();

            foreach (var prop in properties)
            {
                string value = prop.PropertyType == typeof(string)
                   ? $"\"{prop.GetValue(obj)}\""
                   : prop.GetValue(obj).ToString();

                keyValue.Add($"\"{prop.Name}\":{value}");
            }

             return "{" + string.Join(",", keyValue) + "}";
        }
    }


    public class ClientSerialize
    {
        public static void Run()
        {
            var p1 = new Person { Name = "Omid", Age = 42 };
            JsonSerialize.Serialize(p1);
        }
    }
}