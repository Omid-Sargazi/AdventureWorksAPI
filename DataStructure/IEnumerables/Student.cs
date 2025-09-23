namespace DataStructure.IEnumerables
{
    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public static void RunStudent()
        {
            List<Student> students = new List<Student>
            {
                new Student {Name="Omid",Grade=100},
                new Student{Name = "Saeed",Grade=90},
                new Student {Name="Vahid", Grade=90}
            };

            Console.WriteLine("Show with IEnumarable:");

            IEnumerable<Student> enumarableStudents = students;//UpCasting

            foreach (var item in enumarableStudents)
            {
                Console.WriteLine($"{item.Name}:{item.Grade}");
            }


            IList<Student> listStudents = students;//UpCasting

            listStudents.Add(new Student { Name = "Saleh", Grade = 80 });
            listStudents.RemoveAt(1);

            Console.WriteLine($"first student:{listStudents[1].Name}:{listStudents[1].Grade}");

            IDictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

            foreach (var item in students)
            {
                studentDictionary[item.Name] = item;
            }

            if (studentDictionary.TryGetValue("Omid", out Student x))
            {
                Console.WriteLine($"omid finded : {x.Name}:{x.Grade}");
            }

            studentDictionary["Samyar"] = new Student { Name = "samyar", Grade = 70 };

            foreach (var item in studentDictionary)
            {
                Console.WriteLine($"");
            }

            ICollection<Student> collectioStudents = students;//UpCasting

            collectioStudents.Add(new Student { Name = "Zini", Grade = 65 });
            collectioStudents.Remove(students[0]);
            Console.WriteLine($"{collectioStudents.Count}");
        }

        private List<Student> FilteredeByGrade(List<Student> students, int minGrade)
        {
            var result = new List<Student>();

            foreach (var student in students)
            {
                if (student.Grade >= minGrade)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> FilterByName(List<Student> students, string namePrefix)
        {
            var result = new List<Student>();

            foreach (var student in students)
            {
                if (student.Name.StartsWith(namePrefix))
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}