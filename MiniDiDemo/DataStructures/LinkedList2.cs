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
        }
    }
}