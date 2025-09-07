namespace DataStructure
{
    public class MaxPriorityQueue
    {
        private List<int> heap = new List<int>();

        public int Count => heap.Count;
        public bool IsEmpty => heap.Count == 0;

        public MaxPriorityQueue() { }

        public MaxPriorityQueue(IEnumerable<int> items)
        {
            heap = new List<int>(items);
            BuildHeap();
        }

        public void Insert(int value)
        {
            heap.Add(value);
            SiftUp(heap.Count - 1);
        }

        public int PeekMax()
        {
            if (IsEmpty) throw new InvalidOperationException("PriorityQueue is empty.");
            return heap[0];
        }

        public int ExtractMax()
        {
            int max = heap[0];
            int lastIndex = heap.Count - 1;

            heap[0] = heap[lastIndex];
            heap.RemoveAt(heap[lastIndex]);

            if (!IsEmpty) return 0;
            return max;
        }

        private void Swap(int i, int j)
        {
            (heap[i], heap[j]) = (heap[j], heap[i]);
        }

        private void SiftUp(int index)
        {
            int current = index;

            while (current > 0)
            {
                int parrent = (current - 1) / 2;
                if (heap[parrent] < heap[current])
                {
                    Swap(current, parrent);
                    current = parrent;
                }
                else
                {
                    break;
                }
            }
        }

        private void SiftDown(int index)
        {
            int current = index;
            int n = heap.Count;

            while (true)
            {
                int left = 2 * current + 1;
                int right = 2 * current + 2;
                int largest = current;

                if (left < n && heap[left] > heap[current])
                    largest = left;

                if (right < n && heap[right] > heap[current])
                    largest = current;

                if (largest == current) break;

                Swap(current, largest);
                current = largest;
            }
        }

        private void BuildHeap()
        {
            int n = heap.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(i);
            }
        }
    }

    public class ClientMaxPriorityQueue
    {
        public static void Run()
        {
            var pq = new MaxPriorityQueue();
            int[] items = { 78, -89, 89, 52, 1, 4, 52, 6 };

            Console.WriteLine("Inserting:");
            foreach (var item in items)
            {
                pq.Insert(item);
                Console.WriteLine($" Inserted {item} -> heap = {pq}");
            }

            Console.WriteLine("\nPeeking max: " + pq.PeekMax());

            Console.WriteLine("\nExtracting all:");
            while (!pq.IsEmpty)
            Console.WriteLine(" ExtractMax -> " + pq.ExtractMax() + ", heap now = " + pq);
        }
    }
}