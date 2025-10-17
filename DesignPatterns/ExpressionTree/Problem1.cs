using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace DesignPatterns.ExpressionTree
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ExpressionTreeProblem1
    {
        public static Expression<Func<T, bool>> BuildExpression<T>(string property, string op, object value)
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
                _ => throw new NotSupportedException(),
            };

            return Expression.Lambda<Func<T, bool>>(body, param);
        }
        
        public static Expression<Func<T,bool>> CombineExpressions<T>(List<Expression<Func<T,bool>>> expressions, string logicalOperator="AND")
        {
            if (expressions == null || expressions.Count == 0)
            {
                throw new ArgumentException("No expression to combine");
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? combined = null;

            foreach (var expr in expressions)
            {
                var invoked = Expression.Invoke(expr, parameter);
                if (combined == null)
                {
                    combined = invoked;
                }
                else
                {
                    combined = logicalOperator.ToUpper() switch

                    {
                        "AND" => Expression.AndAlso(combined, invoked),
                        "OR" => Expression.OrElse(combined, invoked),
                        _ => throw new NotSupportedException("Only OR/AND suported.")
                    };

                }
            }

            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }
    }
}