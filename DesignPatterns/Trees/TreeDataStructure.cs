namespace DesignPatterns.Trees
{
    public class NodeOfTree
    {
        public int Data { get; set; }
        public NodeOfTree? Left { get; set; }
        public NodeOfTree? Right { get; set; }

        public NodeOfTree(int data)
        {
            Data = data;

            Left = Right = null;
        }
    }

    public class TreeDataStructure
    {
        private NodeOfTree _root;
        public TreeDataStructure() { }
        public TreeDataStructure(NodeOfTree node)
        {
            _root = node;
        }

        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new NodeOfTree(value);
            }

            _root = AddTree(_root, value);
        }

        private NodeOfTree AddTree(NodeOfTree node, int value)
        {
            if (node == null) return new NodeOfTree(value);
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


        public void Print()
        {
            InOrder(_root);
        }
        private void InOrder(NodeOfTree root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Data + " ");
                InOrder(root.Right);
            }
            
        }

    }

    public class BSTClient
    {
        public static void Run()
        {
            TreeDataStructure t1 = new TreeDataStructure();
            t1.Add(10);
            t1.Add(8);
            t1.Add(22);
            t1.Add(20);
            t1.Add(25);
            t1.Add(19);
            t1.Add(21);
            t1.Add(5);
            t1.Add(9);
            t1.Add(4);
            t1.Add(6);
            t1.Print();

        }
    }
}