using System.Data.Common;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Text.Json;
using LiveCoding.LeetCode;
using LiveCoding.LinqExamples;
using LiveCoding.ObjectValidator;
using LiveCoding.Patterns;
using LiveCoding.QueryExample;
using LiveCoding.Reflections;

namespace LiveCoding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Reflectionssss");

            Clientvalidator.Run();
            QueryExamplee.Run();


            // var container = new DIContainer();
            // container.Register<IEmailService, SmtpEmailService>();
            // container.Register<ILogService, FileLogger>();
            // container.Register<IPaymentProcessor, CreditCardPayment>();

            // var paymentService = container.GetService<PaymentService>();


            // var container = new DIContainerLibaray();

            // container.Register<IBookService, BookService>();
            // container.Register<IMemberService, MemberService>();
            // container.Register<INotificationService, EmailNotificationService>();

            // var lib = container.GetService<Library>();

            // ClientStateMachin.Run();



            // lib.RunLibraryOperations();
            // Console.ReadLine();

            // ClientSerialize.Run();

            // var nums = new int[] { 1, 2, 3, 4 };

            // ClientLazy.Run();

            // Console.WriteLine($"Singleton");
            // Client.Run();

            // Lazy<int> lazyX = new Lazy<int>(() => 2);
            // Console.WriteLine(lazyX.Value + "  lazy");

            // Func<string> ins = () =>
            // {
            //     Console.WriteLine("helllo");
            //     return "Hello";
            // };

            // Console.WriteLine(ins);


            // var p = new Person { Name = "Omid", Age = 42, IdCode = 20 };

            // Dictionary<string, List<int>> dic = [];

            // if (!dic.TryGetValue("A", out List<int>? value))
            // {
            //     value = [];
            //     dic["A"] = value;
            // }

            // value.Add(1);
            // value.Add(2);
            // value.Add(3);

            // foreach (var item in dic)
            // {

            //     Console.WriteLine(item.Value[1]);

            // }

            // var res = SerializeDemo.Serialize(p);

            // Console.WriteLine(res);

            // SerializeDemo.Desrialize<Person>(res);


            // // var str2 = JsonSerializer.Serialize(p);
            // // Console.WriteLine(str2);

            // // Person P = JsonSerializer.Deserialize<Person>(str2);
            // // Console.WriteLine(P.Age);





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



        public static void Desrialize<T>(string str)
        {
          
            ParseState currentState = ParseState.Start;
            StringBuilder currentValue = new StringBuilder();
            StringBuilder currentKey = new StringBuilder();
            Dictionary<string, object> result = new();

            Console.WriteLine("Desrializing................");
            var t = typeof(T);
            Console.WriteLine(t);

            
            foreach (char c in str)
            {
                switch (currentState)
                {
                    case ParseState.Start:
                        if (c == '{') currentState = ParseState.InKey;
                        break;
                    case ParseState.InKey:
                        if (c == '"')
                        {
                            currentState = ParseState.ReadingKey;
                            currentKey.Clear();
                        }
                        break;
                    case ParseState.ReadingKey:
                        if (c == '"')
                        {
                            currentState = ParseState.AfterColon;
                        }
                        else
                        {
                            currentKey.Append(c);
                        }
                        break;
                    case ParseState.AfterColon:
                        if (c == ':')
                        {
                            currentState = ParseState.InValue;
                            currentValue.Clear();
                        }
                        break;

                    case ParseState.InValue:
                        if (c == '"')
                        {
                            currentState = ParseState.ReadingKey;
                            currentKey.Clear();
                        }
                        else
                        {
                            currentKey.Append(c);
                        }
                        break;
                            

                }
                // Console.WriteLine(c);
            }
            Console.WriteLine(currentKey);
            
        }
    }
    






    public enum ParseState { Start, InKey, AfterColon, InValue, InString, End, ReadingKey, ReadingValue };
    public record struct Money(decimal Amount, string Cirrency);
    
   
}