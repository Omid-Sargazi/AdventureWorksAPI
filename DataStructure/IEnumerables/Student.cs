namespace DataStructure.IEnumerables
{
    public class Student
    {
        public string Name { get; set; }
        public string Grade { get; set; }

        public static void RunStudent()
        {
            List<Student> students = new List<Student>
            {
                new Student {Name="Omid",Grade="A"},
                new Student{Name = "Saeed",Grade="B"},
                new Student {Name="Vahid", Grade="C"}
            };

            Console.WriteLine("Show with IEnumarable:");

            IEnumerable<Student> enumarableStudents = students;//UpCasting

            foreach (var item in enumarableStudents)
            {
                Console.WriteLine($"{item.Name}:{item.Grade}");
            }


            IList<Student> listStudents = students;//UpCasting

            listStudents.Add(new Student { Name = "Saleh", Grade = "A" });
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

            studentDictionary["Samyar"] = new Student { Name = "samyar", Grade = "S" };

            foreach (var item in studentDictionary)
            {
                Console.WriteLine($"");
            }

            ICollection<Student> collectioStudents = students;//UpCasting

            collectioStudents.Add(new Student { Name = "Zini", Grade = "Z" });
            collectioStudents.Remove(students[0]);
            Console.WriteLine($"{collectioStudents.Count}");
        }
    }
}