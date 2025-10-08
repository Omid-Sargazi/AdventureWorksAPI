namespace MiniDiDemo.Model
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class Reflections
    {
        public static void Run()
        {
            Person p1 = new Person { Age = 42, Name = "Omid" };

            var type = typeof(Person);


            var nameProps = type.GetProperties();

            var nameProp = type.GetProperty("Name");
            nameProp.SetValue(p1, "Saeed");

            foreach (var pro in nameProps)
            {
                // pro.SetValue(p1, "Saeed");
                // pro.SetValue(p1, 40);
                Console.WriteLine(pro.GetValue(p1));
            }
        }
    }
}