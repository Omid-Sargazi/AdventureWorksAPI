using System.Dynamic;

namespace DataStructure.ExplanationExpandoObject
{
    public class ExplanationExpandoObject
    {
        public static void Run()
        {
            dynamic wallet = new ExpandoObject();

            wallet.Name = "Omid";
            wallet.Age = 25;
            wallet.city = "Tehran";

            wallet.introduced = new Action(() =>
            {
                Console.WriteLine($"My name is {wallet.Name}, I'm {wallet.Age} years old and I live in {wallet.city}");
            });

            wallet.introduced();
        }

        public static void Run2()
        {
            dynamic profile = new ExpandoObject();

            profile.Name = "Ali";
            profile.Age = 30;


            profile.Email = "o@o.com";
            profile.Phone = "0912-000-0000";

            profile.ShowInfo = new Action(() =>
            {
                Console.WriteLine($"Name: {profile.Name}");
                Console.WriteLine($"Age: {profile.Age}");
                if (profile.Email != null)
                {
                    Console.WriteLine($"Email: {profile.Email}");
                }
            });

            profile.ShowInfo();
        }
    }
}