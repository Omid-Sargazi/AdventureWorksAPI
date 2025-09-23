using System.Globalization;

namespace AlgorithemAndDataStructure.LinqInCSahrp
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }


        public static void RunStudent()
        {
            List<Student> students = new List<Student>
            {
                new Student{Name="Omid", Grade=100},
                new Student{Name = "Saeed",Grade=95},
                new Student{Name = "Vahid", Grade=90},
                new Student{Name="Saleh", Grade=80},
                new Student{Name="Zini", Grade=65}
            };

            IEnumerable<Student> enumerableStudents = students;//UpCasting
            foreach (var student in enumerableStudents)
            {
                Console.WriteLine($"{student.Name}:{student.Grade}");
            }
        }
    }
}