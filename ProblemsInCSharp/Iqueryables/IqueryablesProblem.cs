using Microsoft.VisualBasic;

namespace ProblemsInCSharp.Iqueryables
{
    public class User
    {
        public string Name;
        private IChatRoomMediator _mediator;
        public User(string name, IChatRoomMediator mediator)
        {
            _mediator = mediator;
            Name = name;
            _mediator.Register(this);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{message} sent to mediator");
            _mediator.Send(message, this);
        }

        public void ReceiveMessage(string message, User sender)
        {
            Console.WriteLine($"{Name} received message from {sender.Name}: {message}");
        }
    }
    public interface IChatRoomMediator
    {
        void Send(string message, User sender);
        void Register(User user);
    }

    public class ChatRoomMediator : IChatRoomMediator
    {
        private List<User> _users = new();
        public void Register(User user)
        {
            _users.Add(user);
        }

        public void Send(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender);
                }

            }
        }
    }

    public class Client
    {
        public static void Run()
        {
            IChatRoomMediator mediator;
        }
    }
}