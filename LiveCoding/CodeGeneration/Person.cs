using System.Reflection;
using System.Text;

namespace LiveCoding.CodeGeneration
{
    public class Personnn
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    public class GenerationCustome
    {

        public static void Run(object obj)
        {
            Type t = obj.GetType();


            StringBuilder codeBuilder = new StringBuilder();
            PropertyInfo[] properties = t.GetProperties();
            MethodInfo[] methodInfos = t.GetMethods();
            GenerateDTO(obj);



        }


        public static void GenerateDTO(object obj)
        {
            Type type = obj.GetType();
            StringBuilder codeBuilder = new StringBuilder();
            PropertyInfo[] properties = type.GetProperties();
            codeBuilder.AppendLine($"public class {type.Name}DTo");
            codeBuilder.AppendLine("{");
            foreach (PropertyInfo property in properties)
            {
                string typeName = GetTypeAlias(property.PropertyType);
                codeBuilder.AppendLine($"    public {typeName} {property.Name} {{ get; set; }}");
            }
            codeBuilder.AppendLine("}");

            Console.WriteLine(codeBuilder);


        }

        private static string GetTypeAlias(Type type)
        {
            if (type == typeof(string)) return "string";
            if (type == typeof(int)) return "int";
            if (type == typeof(bool)) return "bool";
            return type.Name;
        }
    }


    public class ClientGeneration
    {
        public static void Run()
        {
            Person p1 = new Person { Name = "Omid", Age = 42 };

            GenerationCustome.Run(p1);
        }
    }
}