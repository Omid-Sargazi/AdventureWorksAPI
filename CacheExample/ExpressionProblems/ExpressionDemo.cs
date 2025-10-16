using System.Linq.Expressions;

namespace CacheExample.ExpressionProblems
{
    public class User
    {
        public int Age { get; set; }
    }
    public class ExpressionDemo
    {
        public static void Run()
        {
            //u=>u.Age>30;

            var param = Expression.Parameter(typeof(User), "u");
            var prop = Expression.Property(param, nameof(User.Age));
            var constant = Expression.Constant(30);

            var body = Expression.GreaterThan(prop, constant);

            var lambda = Expression.Lambda<Func<User, bool>>(body, param);

            Console.WriteLine(lambda);

        }
    }
}