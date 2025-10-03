using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace LiveCoding.Reflections
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
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
            var p1 = new Person { Name = "Omid", Age = 42, Id = 12, LastName = "Sa" };

            // var str = JsonSerializer.Serialize(p1);
            // Console.WriteLine(str);
            // JsonSerialize.Serialize(p1);


            string str = @"{""Name"":""Omid"",""Age"":42}";
            string str1 = "{\"Name\":\"Omid\",\"Age\":42}";

            string str2 = "{\"Name\":\"Omid\",\"Age\":42,\"Id\":12,\"LastName\":\"Sa\"}";
            DeserializeJson.Deserialize(str2);
        }
    }

    public class DeserializeJson
    {
        public static void Deserialize(string json)
        {
            string context = json.Trim('{', '}');

            string[] kayValuePairs = context.Split(',');

            var result = new Dictionary<string, object>();

            foreach (var pair in kayValuePairs)
            {
                string[] parts = pair.Split(':');
                string value = parts[1];
                if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    value = value.Trim('"');
                }
                else if (int.TryParse(value, out int intVaue))
                {
                    value = intVaue.ToString();
                }
                else if (bool.TryParse(value, out bool boolValue))
                {
                    value = boolValue.ToString();
                }

                Console.WriteLine(parts[0]);
                Console.WriteLine(value);
            }
        }
    }

    public enum JsonState
    {
        Start,
        InKey,
        InValue,
        InString,
        End,
        InNumber
    }

    public class JsonParser
    {
        private JsonState _currentState = JsonState.Start;
        private string _currentKey = "";
        private string _currentValue = "";

        private Dictionary<string, object> _result = new Dictionary<string, object>();

        public void ProcessChar(char c)
        {
            switch (_currentState)
            {
                case JsonState.Start:
                    if (c == '{') _currentState = JsonState.InKey;
                    break;
                case JsonState.InKey:
                    if (c == '"') _currentState = JsonState.InString;
                    break;
                case JsonState.InString:
                    if (c == '"')
                    {
                        _currentState = JsonState.InValue;
                        //save key
                    }
                    else
                    {
                        //add
                    }
                    break;
                case JsonState.InValue:
                    if (c == '"') _currentState = JsonState.InString;
                    else if (char.IsDigit(c)) _currentState = JsonState.InNumber;
                    break;
                    
            }
        }
    }


}