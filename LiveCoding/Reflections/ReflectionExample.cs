namespace LiveCoding.Reflections
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public interface IBookService
    {
        void BorrowBook(int bookId, int memberId);
        void ReturnBook(int bookId);
        List<Book> GetAvailableBooks();
    }

    public interface IMemberService
    {
        void RegisterMember(string name, string email);
        Member GetMember(int id);
    }

    public interface INotificationService
    {
        void SendBorrowNotification(string memberEmail, string bookTitle);
        void SendReturnNotification(string memberEmail, string bookTitle);
    }

    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly INotificationService _notificationService;

        public BookService(INotificationService notificationService)
        {
            _notificationService = notificationService;

            _books.Add(new Book { Id = 1, Title = "C# Programming", Author = "John Doe", IsBorrowed = false });
            _books.Add(new Book { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith", IsBorrowed = false });
        }
        public void BorrowBook(int bookId, int memberId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                _notificationService.SendBorrowNotification("member@email.com", book.Title);
                Console.WriteLine($"Book '{book.Title}' borrowed by member {memberId}");
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return _books.Where(b => !b.IsBorrowed).ToList();
        }

        public void ReturnBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsBorrowed)
            {
                book.IsBorrowed = false;
                _notificationService.SendReturnNotification("member@email.com", book.Title);
                Console.WriteLine($"Book '{book.Title}' returned");
            }
        }
    }

    public class MemberService : IMemberService
    {
        private readonly List<Member> _members = new List<Member>();
        public Member GetMember(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public void RegisterMember(string name, string email)
        {
            var newMember = new Member
            {
                Id = _members.Count + 1,
                Name = name,
                Email = email
            };
            _members.Add(newMember);
            Console.WriteLine($"Member '{name}' registered with ID: {newMember.Id}");
        }
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendBorrowNotification(string memberEmail, string bookTitle)
        {
            Console.WriteLine($"Email to {memberEmail}: You borrowed '{bookTitle}'");
        }

        public void SendReturnNotification(string memberEmail, string bookTitle)
        {
            Console.WriteLine($"Email to {memberEmail}: You returned '{bookTitle}'");
        }
    }

    public class Library
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;

        public Library(IBookService bookService, IMemberService memberService)
        {
            _bookService = bookService;
            _memberService = memberService;
        }

        public void RunLibraryOperations()
        {
            // ثبت عضو جدید
            _memberService.RegisterMember("Ali Rezaei", "ali@email.com");

            // نمایش کتاب‌های available
            var availableBooks = _bookService.GetAvailableBooks();
            Console.WriteLine("Available books:");
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
            }

            // قرض گرفتن کتاب
            _bookService.BorrowBook(1, 1);

            // برگرداندن کتاب
            _bookService.ReturnBook(1);
        }
    }

    public class DIContainerLibaray
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            _registrations[typeof(TInterface)] = typeof(TImplementation);
        }

         public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type serviceType)
        {
            if (_registrations.TryGetValue(serviceType, out Type implementationType))
            {
                serviceType = implementationType;
            }

            var constructors = serviceType.GetConstructors();
            if (constructors.Length == 0)
            {
                throw new InvalidOperationException($"No constructor found for {serviceType.Name}");
            }

            var constructor = constructors[0];
            var parameters = constructor.GetParameters();

            var parameterInstances = new List<object>();

            foreach (var parameter in parameters)
            {
                
                var parameterInstance = GetService(parameter.ParameterType);

                parameterInstances.Add(parameterInstance);
            }

            return constructor.Invoke(parameterInstances.ToArray());
        }
    }
    

    
}