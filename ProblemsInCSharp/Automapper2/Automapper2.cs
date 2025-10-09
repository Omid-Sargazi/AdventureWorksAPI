namespace ProblemsInCSharp.Automapper2
{
    public class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }
    }

    public class PersonDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get; set; }
        public int YearsOld { get; set; }
         public int Age { get; set; }
        public bool Status { get; set; }
    }
    public class Automapper2Custome
    {
        private static Dictionary<(Type, Type), Dictionary<string, string>> _customeMapping = 
            new Dictionary<(Type, Type), Dictionary<string, string>>();

        public static TTarget Automapper<TSource, TTarget>(TSource source) where TTarget : new()
        {
            TTarget target = new TTarget();


            var sourceProperties = typeof(TSource).GetProperties();
            var targetPropertirs = typeof(TTarget).GetProperties();

            foreach (var targetProp in targetPropertirs)
            {

                

                
                var sourceProp = sourceProperties.FirstOrDefault(p => p.Name == targetProp.Name && p.PropertyType == targetProp.PropertyType);

                if (sourceProp != null)
                {
                    targetProp.SetValue(target, sourceProp.GetValue(source));
                }
            }

            return target;
        }

        public static void CreateMap<TSource, TTarget>(Dictionary<string, string> propertyMapping)
        {
            var key = (typeof(TSource), typeof(TTarget));
            _customeMapping[key] = propertyMapping;
        }
    }

    public class ClientMapper2
    {
        public static void Run()
        {
            var p2 = new Person { FName = "Omid", LName = "Sa", Age = 43, Status = true };

            var res = Automapper2Custome.Automapper<Person, PersonDto>(p2);

            Console.WriteLine(res.Age);
            Console.WriteLine(res.LName);
            Console.WriteLine(res.FName);
        }
    }
}