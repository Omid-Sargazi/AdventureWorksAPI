using System.Globalization;

namespace AlgorithemAndDataStructure.LinqInCSahrp
{
    public delegate bool StudentFilter(Student student);
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


            IList<Student> listStudents = students;//UpCasting

            listStudents.Add(new Student { Name = "Sami", Grade = 78 });
            listStudents.RemoveAt(1);

            Console.WriteLine($"{listStudents[1].Name}:{listStudents[1].Grade}");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}:{student.Grade}");
            }

            IDictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
            foreach (var item in students)
            {
                studentDictionary[item.Name] = item;
            }

            if (studentDictionary.TryGetValue("omid", out Student st))
            {
                Console.WriteLine($"{st.Grade}");
            }

            studentDictionary["abbas"] = new Student { Name = "abbas", Grade = 50 };

            foreach (var item in studentDictionary)
            {
                Console.WriteLine($"{item.Key}:{item.Value.Name}:{item.Value.Grade}");
            }

            var gradeFilter = Student.StudentFilter(students, s => s.Grade > 70);
            var nameFilter = Student.StudentFilter(students, s => s.Name.StartsWith("O"));

            var topStudents = Student.StudentFilter(students, s => s.Grade > 88 && s.Name.StartsWith("s"));

            
        }


        public static IEnumerable<Student> StudentFilter(IEnumerable<Student> students, StudentFilter filter)
        {
            foreach (var item in students)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }
    }
}