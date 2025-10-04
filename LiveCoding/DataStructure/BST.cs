using System.Reflection.Metadata.Ecma335;

namespace LiveCoding.DataStructure
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left;
        public TreeNode Right;
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
        public BST(TreeNode node)
        {
            _root = node;
        }

        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
            }
            _root = AddTree(_root, value);
        }


        private TreeNode AddTree(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);
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
        
        


            
        }

    public class ClientBST
    {
        public static void Run()
        {
            BST b1 = new BST();
            b1.Add(10);
            b1.Add(9);
            b1.Add(8);
        }
    }
}