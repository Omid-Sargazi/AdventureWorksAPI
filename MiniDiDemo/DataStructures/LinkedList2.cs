using System.Security.Cryptography;

namespace MiniDiDemo.DataStructures
{
    public class Node2
    {
        public Node2 Next { get; set; }
        public int Data { get; set; }

        public Node2(int data)
        {
            Data = data;
            Next = null;
        }
    }
    public class LinkedList2
    {
        private Node2 _head;
        public LinkedList2() { }
        public LinkedList2(Node2 node)
        {
            _head = node;
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new Node2(value);
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node2(value);
        }

        public void Reverse()
        {
            var current = _head;
            Node2 prev = null;
            Node2 next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            _head = prev;
        }

        public void Print()
        {
            if (_head == null)
            {
                Console.WriteLine($"List is empty");
                return;
            }

            var current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data}" + "->");
                current = current.Next;
            }
        }

    }

    public class Client
    {
        public static void Run()
        {
            //======================
            //LimkedList
            LinkedList2 l1 = new LinkedList2();
            l1.Add(1);
            l1.Add(10);
            l1.Add(100);
            l1.Add(-11);
            l1.Add(0);
            l1.Print();
            Console.WriteLine("Reverse");
            l1.Reverse();
            l1.Print();
            //======================

            //======================
            BST bST = new BST();
            bST.Add(17);
            bST.Add(10);
            bST.Add(11);
            bST.Add(9);
            bST.Add(8);
            bST.Add(18);
            bST.Add(16);
            bST.Add(19);
            bST.InOrder();
            //======================


        }
    }

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

        private TreeNode AddTree(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if (root.Data > value)
            {
                root.Left = AddTree(root.Left, value);
            }
            if (root.Data < value)
            {
                root.Right = AddTree(root.Right, value);
            }

            return root;
        }

        public void InOrder()
        {
            InOrderTree(_root);
        }

        private void InOrderTree(TreeNode root)
        {
            if (root == null)
            {
                // Console.WriteLine($"List is empty");
                return;
            }

            InOrderTree(root.Left);
            Console.WriteLine(root.Data);
            InOrderTree(root.Right);

        }
    }

    public class MaxHeap
    {
        private List<int> _elements = new();

        private int GetLeftChildIndex(int i) => 2 * i + 1;
        private int GetRightChildIndex(int i) => 2 * i + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;

        private bool HasLeftChild(int i) => GetLeftChildIndex(i) < _elements.Count;
        private bool HasRightChild(int i) => GetRightChildIndex(i) < _elements.Count;
        private bool HasParent(int i) => i > 0;

        private int LeftChild(int i) => _elements[GetLeftChildIndex(i)];
        private int RightChild(int i) => _elements[GetRightChildIndex(i)];
        private int Parent(int i) => _elements[GetParentIndex(i)];

        private void Swap(int i, int j)
        {
            (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
        }
    }
}