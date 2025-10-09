using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ProblemsInCSharp.Automapper
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int YearsOld { get; set; }
    }
    public class AutomapperCustome
    {
        public static TTarget Automapper<TSource, TTarget>(TSource source) where TTarget : new()
        {
            PersonDto dto = new PersonDto();

            var target = new TTarget();

            var sourceProperties = typeof(TSource).GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();

            foreach (var targetProp in targetProperties)
            {
                var sourceProp = sourceProperties.FirstOrDefault(p =>
                    p.Name == targetProp.Name && p.PropertyType == targetProp.PropertyType
                );


                if (sourceProp != null)
                {
                    targetProp.SetValue(target, sourceProp.GetValue(source));
                }
            }

            return target;

        }
    }

    public class ClientMapper
    {
        public static void Run()
        {
            var p1 = new Person
            {
                FirstName = "Omid",
                LastName = "Sa",
                Age = 43,
            };

            var res = AutomapperCustome.Automapper<Person, PersonDto>(p1);

            Console.WriteLine(res.FirstName);
            Console.WriteLine(res.LastName);
            Console.WriteLine(res.YearsOld);
        }
    }
}