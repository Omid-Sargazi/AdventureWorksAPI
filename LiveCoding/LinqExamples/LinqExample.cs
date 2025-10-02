using System.Reflection;
using Microsoft.VisualBasic;

namespace LiveCoding.LinqExamples
{
    public sealed class Category
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public List<Product> Products { get; } = new();
    }

    public sealed class Product
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
        public Category Category { get; init; } = default!;
        public List<OrderItem> OrderItems { get; } = new();
    }

    public sealed class Customer
    {
        public int Id { get; init; }
        public string FullName { get; init; } = default!;
        public List<Order> Orders { get; } = new();
    }

    public sealed class Order
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public int CustomerId { get; init; }
        public Customer Customer { get; init; } = default!;
        public List<OrderItem> Items { get; } = new();
    }

    public sealed class OrderItem
    {
        public int OrderId { get; init; }
        public Order Order { get; init; } = default!;
        public int ProductId { get; init; }
        public Product Product { get; init; } = default!;
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
    }

    public class SeedDate
    {
        public static void Run()
        {
            var categories = new List<Category>
        {
            new() { Id = 1, Name = "Phones" },
            new() { Id = 2, Name = "Laptops" },
        };

            var products = new List<Product>
        {
            new() { Id = 1, Name = "iPhone 15", Price = 1100, CategoryId = 1 },
            new() { Id = 2, Name = "Pixel 9",  Price = 900,  CategoryId = 1 },
            new() { Id = 3, Name = "Dell XPS", Price = 1700, CategoryId = 2 },
        };

            var customers = new List<Customer>
        {
            new() { Id = 1, FullName = "Alice Johnson" },
            new() { Id = 2, FullName = "Bob Smith" }
        };

            var orders = new List<Order>
        {
            new() { Id = 1, CustomerId = 1, CreatedAt = new DateTime(2025,10,01) },
            new() { Id = 2, CustomerId = 2, CreatedAt = new DateTime(2025,10,02) },
        };

            var orderItems = new List<OrderItem>
        {
            new() { OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1100 },
            new() { OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 900  },
            new() { OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 1700 },
        };

            IEnumerable<Product> seq = products;
            var q = seq.Where(p => p.Price > 100);
            var res = q.ToList();


        }


        //==============================================

        //==============================================

    }





    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
    }

    public interface ILogService
    {
        void Log(string message);
    }

    public interface IEmailService
    {
        void SendEmail(string email, string message);
    }

    public class CreditCardPayment : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            return true;
        }
    }

    public class SmtpEmailService : IEmailService
    {
        public void SendEmail(string email, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class FileLogger : ILogService
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class PaymentService
    {
        private readonly IEmailService _emailService;
        private readonly ILogService _logService;
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IEmailService emailService, ILogService logService, IPaymentProcessor paymentProcessor)
        {
            _emailService = emailService;
            _logService = _logService;
            _paymentProcessor = paymentProcessor;
        }
    }


    public class DIContainer
    {
        private Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            _registrations[typeof(TInterface)] = typeof(TImplementation);
        }

        public T GetService<T>()
        {
            Type serviceType = typeof(T);

            ConstructorInfo[] constructors = serviceType.GetConstructors();
            ConstructorInfo constructor = constructors[0];
            ParameterInfo[] parameters = constructor.GetParameters();

            List<object> parameterInstances = new List<object>();

            foreach (var parameter in parameters)
            {
                Type type = parameter.ParameterType;
                if (_registrations.TryGetValue(type, out Type implementationType))
                {
                    
                }
                else
                {
                    throw new Exception($"Service {type.Name} not registered.");
                }
            }
        }
            
    }

}