namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
    public interface IMessageSender
{
    Task<bool> SendAsync(string message, string recipient);
}

public interface IMessageReceiver
{
    Task<string> ReceiveAsync();
    void Subscribe(Action<string> callback);
}

public interface IConnectionValidator
{
    Task<bool> ValidateConnectionAsync();
}

// Concrete Products for SMS
public class SmsSender : IMessageSender
{
    public async Task<bool> SendAsync(string message, string recipient)
    {
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
        await Task.Delay(100);
        return true;
    }
}

public class SmsReceiver : IMessageReceiver
{
    private Action<string> _callback;
    
    public async Task<string> ReceiveAsync()
    {
        await Task.Delay(200);
        return "SMS: Test message received";
    }
    
    public void Subscribe(Action<string> callback) => _callback = callback;
}

public class SmsConnectionValidator : IConnectionValidator
{
    public async Task<bool> ValidateConnectionAsync()
    {
        await Task.Delay(50);
        Console.WriteLine("SMS connection validated");
        return true;
    }
}

// Concrete Products for Email
public class EmailSender : IMessageSender
{
    public async Task<bool> SendAsync(string message, string recipient)
    {
        Console.WriteLine($"Sending Email to {recipient}: {message}");
        await Task.Delay(150);
        return true;
    }
}

public class EmailReceiver : IMessageReceiver
{
    private Action<string> _callback;
    
    public async Task<string> ReceiveAsync()
    {
        await Task.Delay(250);
        return "Email: Test message received";
    }
    
    public void Subscribe(Action<string> callback) => _callback = callback;
}

public class EmailConnectionValidator : IConnectionValidator
{
    public async Task<bool> ValidateConnectionAsync()
    {
        await Task.Delay(80);
        Console.WriteLine("Email connection validated");
        return true;
    }
}

public interface ICommunicationFactory
{
    IMessageSender CreateMessageSender();
    IMessageReceiver CreateMessageReceiver();
    IConnectionValidator CreateConnectionValidator();
}


public class SmsCommunicationFactory : ICommunicationFactory
{
    public IMessageSender CreateMessageSender() => new SmsSender();
    public IMessageReceiver CreateMessageReceiver() => new SmsReceiver();
    public IConnectionValidator CreateConnectionValidator() => new SmsConnectionValidator();
}

public class EmailCommunicationFactory : ICommunicationFactory
{
    public IMessageSender CreateMessageSender() => new EmailSender();
    public IMessageReceiver CreateMessageReceiver() => new EmailReceiver();
    public IConnectionValidator CreateConnectionValidator() => new EmailConnectionValidator();
}

}