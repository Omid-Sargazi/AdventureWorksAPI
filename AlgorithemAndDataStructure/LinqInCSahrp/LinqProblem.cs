using System.Globalization;
using System.Reflection.Metadata;

namespace AlgorithemAndDataStructure.LinqInCSahrp
{
    public record Person(string Name, int Age, string Dept);
    public class LinqProblem
    {
        public static void Run()
        {
            var nums = new int[] { 5, 3, 9, 1, 5, 7 };

            var people = new List<Person>
            {
                new("Omid",42,"IT"),
                new("Saeed",40,"PHP"),
                new("Vahid",36,"Nurse"),
                new("Saleh",15,"Student"),
                new("Mehdi", 30, "IT"),
                new("Neda", 28, "Sales"),
                new("Kian", 22, "HR"),
            };


            var gt5 = nums.Where(n => n > 5);
            Console.WriteLine($"{string.Join(",", gt5)}");

            var it30 = people.Where(p => p.Dept == "IT" && p.Age > 30).Select(n => n.Name);
            Console.WriteLine($"{string.Join(",", it30)}");

            var names = people.Select(p => p.Name);

            var brief = people.Select(p => new { p.Name, isAdult = p.Age > 29 });

            var words = new[] { "linq", "is", "powefull" };
            var chars = words.SelectMany(w => w.ToCharArray());
            Console.WriteLine($"{string.Join(",", chars)}");

            var sorted = people.OrderBy(p => p.Age).ThenBy(p => p.Name);
            var desc = nums.OrderByDescending(n => n);

            var unique = nums.Distinct();
            var uniqueAge = people.DistinctBy(p => p.Age);

            var itNames = people.Where(p => p.Dept == "IT").Select(p => p.Name);
            var hrNames = people.Where(p => p.Dept == "hr").Select(p => p.Name);

            var common = itNames.Intersect(hrNames); 

        }
    }
}