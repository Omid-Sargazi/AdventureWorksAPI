using System.Globalization;
using System.Security.Cryptography;

namespace ProblemsInCSharp.Sortings
{
    public class SortProblems
    {
        public static void Bubble(int[] nums)
        {
            for (int start = nums.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                        swapped = true;
                    }

                }
                if (!swapped) break;
            }

            Console.WriteLine($"{string.Join(",", nums)}");
        }

        public static void Selection(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    (nums[i], nums[minIndex]) = (nums[minIndex], nums[i]);
                }
            }

            Console.WriteLine($"{string.Join(",", nums)}");
        }

        public static void Insertion(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];
                int j = i - 1;
                while (j >= 0 && nums[j] > current)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }
                nums[j + 1] = current;
            }

            Console.WriteLine($"{string.Join(",", nums)}");
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

    public class LinkedList
    {
        private Node _head;
        public LinkedList() { }
        public LinkedList(Node node)
        {
            _head = node;
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

        public void Reverse()/////////////////////////////
        {
            if (_head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }

            var current = _head;
            Node next = null;
            Node prev = null;
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
            if (_head == null) Console.WriteLine("List is Empty");

            var current = _head;
            while (current != null)
            {
                Console.Write(current.Value + "->");
                current = current.Next;
            }
            Console.WriteLine(" ");
        }
    }

    public class CLientList
    {
        public static void Run()
        {
            LinkedList l1 = new LinkedList();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
            l1.Add(4);

            l1.Print();
            l1.Reverse();
            l1.Print();

        }
    }
    
}