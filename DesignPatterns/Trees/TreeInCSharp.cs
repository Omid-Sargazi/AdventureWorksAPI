namespace DesignPatterns.Trees
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
        public BST()
        {

        }

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

            else
            {
                _root = AddTree(_root, value);
            }
        }

        public void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.WriteLine(node.Data + " ");
                InOrder(node.Right);
            }
        }

        public void PrintInOrder()
        {
            InOrder(_root);
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

            b1.PrintInOrder();
        }
    }


    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedListInCSharp
    {
        private Node _head;
        public LinkedListInCSharp() { }
        public LinkedListInCSharp(Node head)
        {
            _head = head;
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value);
        }

        public void PrintList()
        {
            if (_head == null) Console.WriteLine("List is empty");
            var current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }

    public class CLientLinkedList
    {
        public static void Run()
        {
            LinkedListInCSharp l1 = new LinkedListInCSharp();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Add(4);

            l1.PrintList();
        }
    }
}