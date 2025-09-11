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

    public class LoggingDecorator : MessageServiceDecorator
    {
        public LoggingDecorator(IMessageService inner) : base(inner)
        {
        }
        public override void Send(string message)
        {
            Console.WriteLine("[Log] Before send");
            base.Send(message);
            Console.WriteLine("[Log] After send");
        }
    }

    public class RetryDecorator : MessageServiceDecorator
    {
        private readonly int _tries;
        public RetryDecorator(IMessageService inner) : base(inner)
        {
        }

        public override void Send(string message)
        {
           for (int i = 1; i <= _tries; i++)
        {
            try
            {
                base.Send(message);
                return;
            }
            catch (Exception ex) when (i < _tries)
            {
                Console.WriteLine($"[Retry] attempt {i} failed: {ex.Message}");
            }
        }
        }
    }
}