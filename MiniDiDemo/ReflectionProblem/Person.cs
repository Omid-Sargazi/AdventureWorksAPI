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
            var p1 = new Person { Name = "Omid", Age = 42, IsHere = true, Job = null };
            var p2 = new Person { Name = "Saeed", Age = 40, IsHere = false, Job = "PHP" };
            RefCustome.Run(p1);

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

            // foreach (var p in pairs)
            // {
            //     if (p.Value == null)
            //     {
            //         stringBuilder.Append($"\"{p.Key}\"");
            //         stringBuilder.Append(":");
            //         stringBuilder.Append("null");
            //         stringBuilder.Append(",");
            //     }
            //     else if (p.Value is string)
            //     {
            //         stringBuilder.Append($"\"{p.Key}\"");
            //         stringBuilder.Append(":");
            //         stringBuilder.Append($"\"{p.Value}\"");
            //         stringBuilder.Append(",");

            //     }

            //     else if (p.Value.GetType().IsValueType)
            //     {
            //         stringBuilder.Append($"\"{p.Key}\"");
            //         stringBuilder.Append(":");
            //         stringBuilder.Append($"{p.Value}");
            //         stringBuilder.Append(",");
            //     }
            //     else
            //     {

            //     }
            //     // Console.WriteLine($"{string.Join(",", pairs.Values)}");
            // }
            // if (stringBuilder.Length > 1 && stringBuilder[stringBuilder.Length - 1] == ',')
            // {
            //     stringBuilder.Remove(stringBuilder.Length - 1, 1);
            // }
            //         stringBuilder.Append("}");

            var properties = new List<string>();
            foreach (var p in pairs)
            {
                string formattedValue = FormatValue(p.Value);
                properties.Add($"\"{p.Key}\":{formattedValue}");
            }
            stringBuilder.Append(string.Join(",", properties));
            stringBuilder.Append("}");


            // Console.WriteLine(stringBuilder);

            DeserializedJson.Deserialized<Person>(stringBuilder.ToString());


        }

        private static string FormatValue(object value)
        {
            if (value == null)
                return "null";
            else if (value is string)
                return $"\"{value}\"";
            else if (value is bool)
                return value.ToString().ToLower(); // true/false
            else
                return value.ToString();
        }
    }


    public class DeserializedJson
    {
        public static void Deserialized<T>(string json)
        {

            json = json.Trim('{', '}');
            string[] keyValue = json.Split(',');

            T newObj = Activator.CreateInstance<T>();
            Type t = newObj.GetType();
            var props = t.GetProperties();

            foreach (string pair in keyValue)
            {
                string[] parts = pair.Split(':');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim('"');
                    string value = parts[1].Trim();

                    PropertyInfo targetProp = props.FirstOrDefault(p => p.Name == key);

                    if (targetProp != null && targetProp.CanWrite)
                    {
                        object convertedValue = ConvertValue(value, targetProp.PropertyType);
                        targetProp.SetValue(newObj, convertedValue);
                    }
                }
                Console.WriteLine(pair);
            }


        }

        private static object ConvertValue(string value, Type targetType)
        {
            if (value == null)
            {
                return null;
            }
            else if (targetType == typeof(string))
            {
                return value.Trim('"');
            }
            else if (targetType == typeof(int))
            {
                return int.Parse(value);
            }
            else if (targetType == typeof(bool))
            {
                return bool.Parse(value.ToLower());
            }

            return value;
        }
    }
}