using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LiveCoding.ObjectValidator
{
    public class Person
    {
        [Required]
        [MaxLength(2)]
        public string Name { get; set; }
        
       [Range(2, 80)]
        public int Age { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }
    }

    public class ObjectValidator<T>
    {
        private T _obj;

        public ObjectValidator(T obj)
        {
            _obj = obj;
        }
        

        public void Validate()
        {
            Type type = typeof(T);

            var methods = type.GetMethods();
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                bool isRequired = item.GetCustomAttributes(typeof(RequiredAttribute), false).Length > 0;

                var value = item.GetValue(_obj);
                if (isRequired)
                {

                    if (value == null || (value is string str && string.IsNullOrEmpty(str)))
                    {
                        Console.WriteLine($"Errro:{item.Name} is Required");
                    }
                }

                if (item.IsDefined(typeof(EmailAttribute), false) && value is string email)
                {
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine($"Errro : {item.Name} must be valid email.");
                    }
                }

                if (item.IsDefined(typeof(RangeAttribute), false) && value is int number)
                {
                    var rangeAttr = (RangeAttribute)item.GetCustomAttributes(typeof(RangeAttribute), false)[0];

                    if (number < rangeAttr.Min || number > rangeAttr.Max)
                    {
                        Console.WriteLine($"ERROR: {item.Name} must be between {rangeAttr.Min} and {rangeAttr.Max}!");
                    }
                }


            }
        }
    }


    public class Clientvalidator
    {
        public static void Run()
        {
            Person p1 = new Person { Name = "ollllll", Age = 42, Email = "o.com" };

            var vali = new ObjectValidator<Person>(p1);
            vali.Validate();

        }
    }

    public class RequiredAttribute : Attribute { }

    public class EmailAttribute : Attribute { }
    public class RangeAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }
        public RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}