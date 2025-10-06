namespace MiniDiDemo.DataStructure
{
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

    public class LinkedList
    {
        private Node _head;
        public LinkedList() { }
        public LinkedList(Node head)
        {
            _head = head;
        }

        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value);
        }

        public void Reverse()
        {
            var current = _head;
            Node prev = null;
            Node next = null;
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
                Console.WriteLine("List is Empty");
                return;
            }

            var current = _head;
            while (current != null)
            {
                Console.Write($"{current.Value}");
                current = current.Next;
                if (current != null)
                {
                    Console.Write("->");
                }
            }
        }

    }

    public class ClientLinkedList
    {
        public static void Run()
        {
            LinkedList l1 = new LinkedList();
            l1.Add(1);
            l1.Add(110);
            l1.Add(111);
            l1.Add(11);
            l1.Print();
            l1.Reverse();
            Console.WriteLine(" ");
            l1.Print();
        }
    }
}