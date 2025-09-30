using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace LiveCoding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Person { Name = "Omid", Age = 42, IdCode = 20 };

            Dictionary<string, List<int>> dic = [];

            if (!dic.TryGetValue("A", out List<int>? value))
            {
                value = [];
                dic["A"] = value;
            }

            value.Add(1);
            value.Add(2);
            value.Add(3);

            foreach (var item in dic)
            {

                Console.WriteLine(item.Value[1]);

            }

            var res = SerializeDemo.Serialize(p);

            Console.WriteLine(res);


            // var str2 = JsonSerializer.Serialize(p);
            // Console.WriteLine(str2);





        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdCode { get; set; }
        public bool Status { get; set; }
        public bool Status1 { get; set; }
        public bool Status2 { get; set; }
        public string Country { get; set; } = null;
    }

    public class SerializeDemo
    {
        public static string Serialize(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }
            var dic = new Dictionary<string, object>();
            StringBuilder s = new();
            string res = "";


            foreach (var item in properties)
            {

                // Console.WriteLine(item.Name + " " + item.GetValue(obj));
                var x = item.GetValue(obj);

                if (!dic.TryGetValue(item.Name, out object val))
                {
                    var value = val;
                }
                dic[item.Name] = item.GetValue(obj);
            }

            s.Append('{');
            bool firstItem = true;

            foreach (var item in dic)
            {
                if (!firstItem)
                {
                    s.Append(',');
                }
                if (item.Value == null)
                {
                    Console.WriteLine("null");
                }

                else if (item.Value.GetType() == typeof(string))
                {
                    // string.Join(",")
                    res = $"\"{item.Key}\":\"{item.Value}\"";
                    // Console.WriteLine(res);

                }
                else if (item.Value.GetType() == typeof(int))
                {
                    res = $"\"{item.Key}\":{item.Value}";
                    // Console.WriteLine(res);

                }
                else if (item.Value.GetType() == typeof(bool))
                {
                    res = $"\"{item.Key}\":{item.Value.ToString().ToLower()}";
                }


                s.Append(res);
                firstItem = false;

                // Console.WriteLine($"{res}");

            }
            s.Append('}');


            return s.ToString();
        }
    }
    

    public record struct Money(decimal Amount, string Cirrency);
   
}