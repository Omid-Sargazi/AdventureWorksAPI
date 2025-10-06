namespace MiniDiDemo.DataStructure
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BST
    {
        private TreeNode _root;
        public BST() { }
        public BST(TreeNode root)
        {
            _root = root;
        }

        public void Add(int value)
        {
            _root = AddTree(_root, value);
        }

        private TreeNode AddTree(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (node.Data > value)
            {
                node.Left = AddTree(node.Left, value);
            }
            if (node.Data < value)
            {
                node.Right = AddTree(node.Right, value);
            }

            return node;
        }


        public void InOrder()
        {
            PrintInOrder(_root);
        }

        private void PrintInOrder(TreeNode root)
        {
            // if (root == null) Console.WriteLine("Tree is Empty.");
            if (root != null)
            {
                PrintInOrder(root.Left);
                Console.Write(root.Data+" ");
                PrintInOrder(root.Right);
            }
            

        }
    }

    public class CLientTree
    {
        public static void Run()
        {
            BST t1 = new BST();
            t1.Add(1);
            t1.Add(0);
            t1.Add(8);
            t1.Add(7);
            t1.Add(15);
            t1.Add(14);
            t1.Add(16);
            t1.InOrder();
        }
    }
}