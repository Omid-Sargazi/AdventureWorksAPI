namespace Sorting.Trees
{
    public class TreeNode
    {
        public string value { get; set; }
        public List<TreeNode> children { get; set; } = new List<TreeNode>();

        public TreeNode(string vale)
        {
            this.value = vale;
        }

        public void AddChild(TreeNode child)
        {
            children.Add(child);
        }
    }

    public class RunTreeNode
    {
        public static void Run()
        {
            var root = new TreeNode("Hossein");
            var omifd = new TreeNode("Omid");
            var saeed = new TreeNode("Saeed");
            var vahid = new TreeNode("Vahid");
            var saleh = new TreeNode("Saleh");
            var samyar = new TreeNode("Samyar");
            root.AddChild(omifd);
            root.AddChild(saeed);
            root.AddChild(vahid);

            omifd.AddChild(saleh);
            omifd.AddChild(samyar);

            PrintTree(root, 1);
        }

        public static void PrintTree(TreeNode node, int level)
        {
            Console.WriteLine(new string('-', level * 2) + node.value);

            foreach (var item in node.children)
            {
                PrintTree(item, level + 1);
            }
        }
    }
}