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
}