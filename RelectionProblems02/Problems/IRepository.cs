namespace RelectionProblems02.Problems
{
     public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        public int Id { get; set; } 
        public List<Product> products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Inventory
    {
        public int Id { get; set; }
        public int Number { get; set; }
    }

    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        void GetAll();
        void GetById(int id);
    }

    public interface IOrderRepository
    {
        void Add(Order user);
        void Delete(Order user);
        void GetAll();
        void GetById(int id);
    }

    public interface IProductRepository
    {
        void Add(Product user);
        void Delete(Product user);
        void GetAll();
        void GetById(int id);
    }

    public interface IInventoryRepository
    {
        void Add(Inventory user);
        void Delete(Inventory user);
        void GetAll();
        void GetById(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void GetAll()
        {
            foreach(var user in _users)
            {
                Console.WriteLine($"{user}");
            }
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public void Add(Order user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order user)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _orders = new List<Product>();

        public void Add(Product user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product user)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Inventory> _orders = new List<Inventory>();

        public void Add(Inventory user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Inventory user)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }
    } 
}