namespace ProblemsInLINQINCSharp.FactoryPattern
{
     public interface INotification
    {
        void Send(string message);
        string GetNotificationType();
    }

    // Concrete Products
    public class EmailNotification : INotification
    {
        public string RecipientEmail { get; }

        public EmailNotification(string recipientEmail)
        {
            RecipientEmail = recipientEmail;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sending Email to: {RecipientEmail}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("Email sent successfully!");
        }

        public string GetNotificationType()
        {
            return "Email";
        }
    }

    public class SmsNotification : INotification
    {
        public string PhoneNumber { get; }

        public SmsNotification(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS to: {PhoneNumber}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("SMS sent successfully!");
        }

        public string GetNotificationType()
        {
            return "SMS";
        }
    }

    public class PushNotification : INotification
    {
        public string DeviceId { get; }

        public PushNotification(string deviceId)
        {
            DeviceId = deviceId;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sending Push Notification to device: {DeviceId}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("Push notification sent!");
        }

        public string GetNotificationType()
        {
            return "Push Notification";
        }
    }
}