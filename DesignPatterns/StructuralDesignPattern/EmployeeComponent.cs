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
}