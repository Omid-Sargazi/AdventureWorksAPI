using System.Reflection;
using System.Text;

namespace RelectionProblems02.ReflectionProblems
{
    public class Person2
    {
        public string Name { get; set; } = "Omid";
        public int Age { get; set; } = 42;
        public bool IsDeveloper { get; set; } = true;
    }


    public class RefClient
    {
        public static string Run(object obj)
        {
            var type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();

            StringBuilder str = new StringBuilder();
            str.Append('{');

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                var name = prop.Name;
                var value = prop.GetValue(obj);

                // string formattedValue = value is string ? $"\"{value}\"" : value.ToString().ToLower()??"null";

                 string formattedValue = value switch

                {
                    string s => $"\"{s}\"",
                    null => "null",
                    bool b => b.ToString().ToLower(),
                    _=>value.ToString().ToLower()
                };

               
                str.Append($"\"{name}\":{formattedValue}");

                if (i < props.Length - 1)
                {
                    str.Append(',');
                }

            }

            str.Append('}');
            return str.ToString();
            
        }
    }
}