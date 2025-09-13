using System.Data;

namespace AlgorithemAndDataStructure.Trees
{
    public class UniversityTree
    {
        public string Name;
        public List<UniversityTree> Children = new List<UniversityTree>();
        public UniversityTree(string name)
        {
            Name = name;
        }
        public void AddChild(UniversityTree child)
        {
            Children.Add(child);
        }
    }

    public class RunUniversityTree
    {
        public static void Run()
        {
            var university = new UniversityTree("My University");
            var engineering = new UniversityTree("Engineering");
            var science = new UniversityTree("Science");
            university.AddChild(engineering);
            university.AddChild(science);

            var computerScience = new UniversityTree("Computer Science");
            var electricalEngineering = new UniversityTree("Electrical Engineering");
            engineering.AddChild(computerScience);
            engineering.AddChild(electricalEngineering);

            var pharmacy = new UniversityTree("Pharmacy");
            var biology = new UniversityTree("Biology");
            science.AddChild(pharmacy);
            science.AddChild(biology);

            PrintTree(university, 0);
        }

        private static void PrintTree(UniversityTree node, int level)
        {
            if (node == null) return;
            Console.WriteLine(new string('-', level * 2) + node.Name);
            foreach (var child in node.Children)
            {
                PrintTree(child, level + 1);
            }
        }
    }
}