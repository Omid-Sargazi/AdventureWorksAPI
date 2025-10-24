using System.Globalization;
using DesignPatterns.StructuralDesignPattern;

namespace DesignPatterns.PaymentNotificationSystem
{

    public interface INotification
    {
        void Send(string message);
    }
    public class Logging : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Notify a message here is Logging:{message}");
        }
    }

    public class SMS : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Notify a message here is SMS:{message}");
        }
    }

    public class Email : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Notify a message here is Email:{message}");
        }
    }


    public delegate void Notify(string message);
    public class Payment
    {
        public event Notify PaymentCompleted;
        private INotification _notification;

        public void Execute(string message)
        {
            Console.WriteLine($"Processing payment: {message}");
            PaymentCompleted.Invoke(message);
        }
    }

    public class PaymentService
    {
        private readonly INotification _emailNotification;
        private readonly INotification _smsNotification;
        private readonly INotification _loggingNotification;

        public PaymentService(INotification email, INotification sms, INotification logging)
        {
            _emailNotification = email;
            _smsNotification = sms;
            _loggingNotification = logging;
        }
        
        public void ProcessPayment(string message)
        {
            var peyment = new Payment();
            peyment.PaymentCompleted += _emailNotification.Send;
            peyment.PaymentCompleted += _loggingNotification.Send;
            peyment.PaymentCompleted += _smsNotification.Send;

            peyment.Execute(message);
        }
    }

    public class ClientPayment
    {
        public static void Run(string message)
        {
            INotification logging = new Logging();
            INotification sms = new SMS();
            INotification email = new Email();
            PaymentService p = new PaymentService(logging, sms, email);
            p.ProcessPayment(message);
        }
    }
}