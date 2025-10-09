namespace ReflectionProblems.Mappers
{
    class Person { public string Name { get; set; } public int Age { get; set; } }
    class PersonDto { public string Name { get; set; } public int Age { get; set; } }

    public class AutomapperCustome
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {

            if (source == null)
                return default;

            
            TTarget target = new TTarget();


            var targetProperties = typeof(TTarget).GetProperties();
            var sourceProperties = typeof(TSource).GetProperties();

            foreach (var sProp in sourceProperties)
            {
                var tProp = targetProperties.FirstOrDefault(p => p.Name == sProp.Name);

                if (tProp == null) continue;
                if (!tProp.CanWrite) continue;

                var value = sProp.GetValue(source);

                tProp.SetValue(target, value);
            }


            return target;
        }
    }


    public class ClientMapper
    {
        public static void Run()
        {
            Person p1 = new Person { Name = "Omid", Age = 43 };
            var res = AutomapperCustome.Map<Person, PersonDto>(p1);

            Console.WriteLine(res.Name);
            Console.WriteLine(res.Age);
        }
    }
}