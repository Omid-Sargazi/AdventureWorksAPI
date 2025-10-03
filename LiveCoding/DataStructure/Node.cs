namespace LiveCoding.DataStructure
{
    public class Node
    {
        public int Data { get; set; }
        public Node next { get; set; }
        public Node(int data)
        {
            Data = data;
            next = null;
        }
    }

    public class LinkedListt
    {
        public Node head;
        public LinkedListt() { }

        public LinkedListt(Node node)
        {
            head = node;
        }

        public void Add(Node node)
        {
            if (head == null)
            {
                head = node;
                return;
            }
            var current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = node;
        }

        public static void Print(LinkedListt l)
        {
            var current = l.head;
            string s = "->";
            while (current != null)
            {

                Console.Write(s + current.Data);
                current = current.next;
            }
        }


        public static void Run()
        {
            LinkedListt l1 = new LinkedListt();
            l1.Add(new Node(1));
            l1.Add(new Node(2));

            Print(l1);
           
        }
    }
}