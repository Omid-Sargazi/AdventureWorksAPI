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

        public static Expression<Func<T,bool>> BuildExpression<T>(string property, string op,object value)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var left = Expression.Property(param, property);
            var right = Expression.Constant(value);

            Expression body = op switch

            {
                ">" => Expression.GreaterThan(left, right),
                "<" => Expression.LessThan(left, right),
                ">=" => Expression.GreaterThanOrEqual(left, right),
                "<=" => Expression.LessThanOrEqual(left, right),
                "==" => Expression.Equal(left, right),
                "!=" => Expression.NotEqual(left, right),
                _ => throw new NotSupportedException($"Operator {op} is not supported...")
            };

            var lmbda = Expression.Lambda<Func<T, bool>>(body, param);
            return lmbda;
        }
    }
}