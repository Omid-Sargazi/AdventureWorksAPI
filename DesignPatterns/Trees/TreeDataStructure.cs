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

    public class NodeLinkedList
    {
        public int Value { get; set; }
        public NodeLinkedList Next { get; set; }
        public NodeLinkedList(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedList
    {
        private NodeLinkedList _head;
        public LinkedList() { }
        public LinkedList(NodeLinkedList node)
        {
            _head = node;
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new NodeLinkedList(value);
                return;
            }

            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new NodeLinkedList(value);
            }
           
        }

        public void AddFirst(int value)
        {
            var newNode = new NodeLinkedList(value);
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            else
            {
                var current = _head;
                _head.Next = newNode;
                newNode.Next = current;

            }
        }

        public void AddLast(int value)
        {
            var newNode = new NodeLinkedList(value);
            if (_head == null)
            {
                _head = newNode;
                return;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void ReverseLinkedList()
        {
            if (_head == null) Console.WriteLine("List is Empty");

            var current = _head;
            NodeLinkedList prev = null;
            NodeLinkedList next = null;
            // _head = null;
            while (current != null)
            {
                next = current.Next;
                next.Next = prev;
                prev = current;
                current = next;
            }
            _head = prev;
        }


        public void Print()
        {
            if (_head == null) Console.WriteLine("List is Empty");
            var current = _head;

            while (current != null)
            {
                Console.Write(current.Value + "->");
                current = current.Next;
            }
        }

    }

    public class LinkedListClinet
    {
        public static void Run()
        {
            LinkedList l1 = new LinkedList();
            l1.AddFirst(100);
            l1.Add(1);
            l1.Add(10);
            l1.Add(111);
            l1.Add(-1);
            l1.AddLast(102);
            l1.Print();
            Console.WriteLine("Reverse is: ");
            l1.ReverseLinkedList();
            l1.Print();
       }
    }
}