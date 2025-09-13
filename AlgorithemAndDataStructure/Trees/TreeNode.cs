using System.Linq.Expressions;

namespace AlgorithemAndDataStructure.Trees
{
    public class TreeNode
    {
        public string Value;
        public List<TreeNode> Children = new List<TreeNode>();
        public TreeNode(string value)
        {
            Value = value;
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }
    }

    public class RunTreeNode
    {
        public static void Run()
        {
            TreeNode root = new TreeNode("Baba");
            TreeNode omid = new TreeNode("Omid");
            TreeNode saeed = new TreeNode("Saeed");
            TreeNode vahid = new TreeNode("Vahid");
            TreeNode saleh = new TreeNode("Saleh");
            TreeNode samyar = new TreeNode("Samyar");

            root.AddChild(omid);
            root.AddChild(saeed);
            root.AddChild(vahid);
            omid.AddChild(saleh);
            omid.AddChild(samyar);


            PrintTree(root, 0);

        }

        private static void PrintTree(TreeNode node, int level)
        {
            if (node == null) return;
            Console.WriteLine(new string('-', level * 2) + node.Value);
            foreach (var child in node.Children)
            {
                PrintTree(child, level + 1);
            }

        }

        
    }
   
}