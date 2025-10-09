using System.Reflection;
using System.Text;

namespace ProblemsInCSharp.SerializedAndDeserialized
{

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string? Country { get; set; }

        public Person() { }
        public Person(int age, string name, bool status, string country)
        {
            Age = age;
            Name = name;
            Status = status;
            Country = country;
        }
    }
    public class JsonSerialized
    {

        public static string Serialized(object obj)
        {
            Dictionary<string, object> pairs = new();
            Type type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                if (!pairs.ContainsKey(prop.Name))
                {
                    pairs[prop.Name] = prop.GetValue(obj);
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");

            var propertiess = new List<string>();

            foreach (var p in pairs)
            {
                string formatedValue = FormatValue(p.Value);
                propertiess.Add($"\"{p.Key}\":{formatedValue}");
            }

            stringBuilder.Append(string.Join(",", propertiess));
            stringBuilder.Append("}");

            Console.WriteLine(stringBuilder);
            return stringBuilder.ToString();
        }

        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return "null";
            }
            else if (value is string)
            {
                return $"\"{value}\"";
            }
            else if (value is bool)
            {
                return value.ToString().ToLower();
            }
            else
            {
               return value.ToString();
            }
        } 
    }


    public class JsonDeserialized
    {
        public static void Deserialized<T>(string str)
        {
            str = str.Trim('{', '}');
            string[] keyValue = str.Split(',');

            T newobj = Activator.CreateInstance<T>();
            Type type = newobj.GetType();
            var props = type.GetProperties();

            foreach (var pairs in keyValue)
            {
                string[] parts = pairs.Split(':');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim('"');
                    string value = parts[1].Trim();

                    PropertyInfo targetInfo = props.FirstOrDefault(p => p.Name == key);

                    if (targetInfo != null && targetInfo.CanWrite)
                    {
                        object converetedValue = ConvertValue(value, targetInfo.PropertyType);
                        targetInfo.SetValue(newobj, converetedValue);
                    }
                }
                Console.Write(parts[0] + " " + parts[1]);
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

    public class Client
    {
        public static void Run()
        {
            Person p1 = new Person { Name = "Omid", Age = 43, Country = null, Status = true };
            Person p2 = new Person { Name = "Saeed", Age = 40, Country = "Lux", Status = false };

            JsonSerialized.Serialized(p1);

            JsonDeserialized.Deserialized<Person>(JsonSerialized.Serialized(p1));
        }
    }
}