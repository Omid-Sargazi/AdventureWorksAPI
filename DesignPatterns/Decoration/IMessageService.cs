namespace DesignPatterns.Decoration
{
    public interface IMessageService
    {
        void Send(string message);
    }

    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Email] {message}");
        }
    }

    public abstract class MessageServiceDecorator : IMessageService
    {
        protected readonly IMessageService _inner;
        public MessageServiceDecorator(IMessageService inner)
        {
            _inner = inner;
        }
        public virtual void Send(string message)
        {
            _inner.Send(message);
        }
    }

    
}