using System.Diagnostics.Tracing;

namespace Sorting.Trees
{
    public class UniversityTree
    {
        public string value { get; set; }
        public List<UniversityTree> children = new List<UniversityTree>();

        public UniversityTree(string value)
        {
            this.value = value;
        }

        public void AddChildren(UniversityTree child)
        {
            children.Add(child);
        }
    }

    public class RunUniversityTree
    {
        public static void Run()
        {
            var university = new UniversityTree("University");
            UniversityTree engineering = new UniversityTree("engineering");
            UniversityTree medicine = new UniversityTree("medicine");

            university.AddChildren(engineering);
            university.AddChildren(medicine);

            UniversityTree computer = new UniversityTree("computer");
            UniversityTree electrical = new UniversityTree("electrical");

            engineering.AddChildren(computer);
            engineering.AddChildren(electrical);

            UniversityTree pharmacy = new UniversityTree("pharmacy");

            UniversityTree dentistry = new UniversityTree("dentistry");

            medicine.AddChildren(pharmacy);
            medicine.AddChildren(dentistry);
            PrintTree(university, 0);

        }


        public static void PrintTree(UniversityTree node, int level)
        {
            Console.WriteLine(new string('-', level * 2) + node.value);

            foreach (var child in node.children)
            {
                PrintTree(child, level + 1);
            }
        }
    }
}