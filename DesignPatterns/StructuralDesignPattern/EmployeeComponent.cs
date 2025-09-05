using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

namespace DesignPatterns.StructuralDesignPattern
{
    public abstract class EmployeeComponent
    {
        public string Name { get; }
        public string Position { get; }

        public EmployeeComponent(string name, string position)
        {
            Position = position;
            Name = name;
        }

        public virtual void Add(EmployeeComponent employee) => throw new NotSupportedException("");
        public virtual void Remove(EmployeeComponent employee) => throw new NotSupportedException("");
        public virtual EmployeeComponent GetChild(int index) => throw new NotSupportedException("");

        public abstract decimal GetSalary();

        public abstract void Display(int depth = 0);
    }

    public interface IEmployeeComponent
    {
        string Name { get; }
        string Position { get; }

        decimal GetSalary();
        void Display(int depth = 0);
    }

    public class Employee : IEmployeeComponent
    {
        public string Name { get; }

        public string Position { get; }

        public decimal Salary;

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string('-', depth)} {Position}: {Name}, Salary = {Salary}");

        }

        public decimal GetSalary()
        {
            return Salary;
        }
    }

    public class EmployeeLeaf : EmployeeComponent
    {
        private readonly decimal _salary;
        public EmployeeLeaf(string name, string position, decimal salary) : base(name, position)
        {
            _salary = salary;
        }

        public override void Display(int depth = 0)
        {
            Console.WriteLine($"{new string('-', depth)}{Position}:{Name},Salary:{_salary}");
        }

        public override decimal GetSalary()
        {
            return _salary;
        }
    }

    public class ClienEmployee
    {
        public static void Run()
        {
            IEmployeeComponent emp1 = new Employee("omid", "Developer", 5000);
            IEmployeeComponent emp2 = new Employee("Saeed", " PHP Developer", 5000);

            emp1.Display();
            emp2.Display();

            Console.WriteLine($"Total Salary = {emp1.GetSalary() + emp2.GetSalary()}");
        }
    }

    public class Manager : IEmployeeComponent
    {

        public string Name { get; }

        public string Position { get; }
        private readonly decimal _salary;
        private readonly List<IEmployeeComponent> _subordinates = new List<IEmployeeComponent>();

        public Manager(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            _salary = salary;
        }

        public void Add(IEmployeeComponent employee) => _subordinates.Add(employee);
        public void Remove(IEmployeeComponent employee) => _subordinates.Remove(employee);

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string('-', depth)}{Position}:{Name}, Salary:{_salary}");
            foreach (var emp in _subordinates)
            {
                emp.Display(depth + 2);
            }
        }

        public decimal GetSalary()
        {
            decimal totalAmount = 0;
            foreach (var emp in _subordinates)
            {
                totalAmount += emp.GetSalary();
            }
            return totalAmount;
        }
    }

    public class ManagerComposite : EmployeeComponent
    {
        private readonly decimal _salary;
        private readonly List<EmployeeComponent> _subordinates = new List<EmployeeComponent>();
        public ManagerComposite(string name, string position, decimal salary) : base(name, position)
        {
            _salary = salary;
        }

        public override void Add(EmployeeComponent employee)
        {
            _subordinates.Add(employee);
        }

        public override void Remove(EmployeeComponent employee)
        {
            _subordinates.Remove(employee);
        }

        public override EmployeeComponent GetChild(int index)
        {
            return _subordinates[index];
        }

        public override void Display(int depth = 0)
        {
            Console.WriteLine($"{new string('-', depth)} {Position}: {Name}, Salary = {_salary}");
            foreach (var emp in _subordinates)
            {
                emp.Display(depth + 2);
            }
        }

        public override decimal GetSalary()
        {
            decimal total = _salary;
            foreach (var emp in _subordinates)
            {
                total += emp.GetSalary();
            }
            return total;
        }
    }

    public class ClientEmployeeLeaf
    {
        public static void Run()
        {
            EmployeeLeaf emp1 = new EmployeeLeaf("Omid", "Developer", 5000);
            EmployeeLeaf emp2 = new EmployeeLeaf("Saeed", "PHP Developer", 5000);

            emp1.Display();
            emp2.Display();

            Console.WriteLine($"Total Salary = {emp1.GetSalary() + emp2.GetSalary()}");
        }
    }
}