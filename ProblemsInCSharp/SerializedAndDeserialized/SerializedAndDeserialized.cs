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

        public static void Serialized(object obj)
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
        public static void Deserialized()
        {

        }
    }

    public class Client
    {
        public static void Run()
        {
            Person p1 = new Person { Name = "Omid", Age = 43, Country = null, Status = true };
            Person p2 = new Person { Name = "Saeed", Age = 40, Country = "Lux", Status = false };

            JsonSerialized.Serialized(p1);
        }
    }
}