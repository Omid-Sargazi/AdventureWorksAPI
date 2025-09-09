namespace Sorting.TopKMinHeap
{
    public class MinPriorityQueue
    {
        private List<int> heap = [];

        public int Count => heap.Count;
        public bool IsEmpty => heap.Count == 0;

        public MinPriorityQueue() { }

        public MinPriorityQueue(IEnumerable<int> items)
        {
            heap = new List<int>(items);
            BuildHeap();
        }

        public void Insert(int value)
        {
            heap.Add(value);
            SiftUp(heap.Count - 1);
        }

        public int PeekMin()
        {
            if (IsEmpty) throw new InvalidOperationException("PriorityQueue is empty.");
            return heap[0];
        }

        public int ExtractMin()
        {
            if (IsEmpty) throw new InvalidOperationException("PriorityQueue is empty.");

            int min = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            if (!IsEmpty) SiftDown(0);
            return min;
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
                if (heap[parrent] > heap[current])
                {
                    Swap(parrent, current);
                    current = parrent;
                }
                else
                {
                    break;
                }
            }
        }

        public void SiftDown(int index)
        {
            int current = index;
            int n = heap.Count;

            while (true)
            {
                int left = 2 * current + 1;
                int right = 2 * current + 2;
                int smallest = current;

                if (left < n && heap[left] < heap[smallest])
                {
                    smallest = left;
                }
                if (right < n && heap[right] < heap[smallest])
                {
                    smallest = right;
                }

                if (smallest == current) break;

                Swap(current, smallest);
                current = smallest;
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

        public override string ToString() => "[" + string.Join(", ", heap) + "]";
    }

    public class TopKMinHeap
    {

        public static List<int> TopK_MinHeap(int[] arr, int k)
        {
            var res = new List<int>();
            if (k <= 0) return res;

            int n = arr.Length;
            if (k >= n)
            {
                var all = arr.ToList();
                all.Sort((a, b) => b.CompareTo(a));
                return all;
            }


            var minPQ = new MinPriorityQueue();

            for (int i = 0; i < k; i++)
            {
                minPQ.Insert(arr[i]);
            }

            for (int i = k; i < n; i++)
            {
                int x = arr[i];
                if (x > minPQ.PeekMin())
                {
                    minPQ.ExtractMin();
                    minPQ.Insert(x);
                }
            }

            while (!minPQ.IsEmpty)
                res.Add(minPQ.ExtractMin());

            res.Reverse();
            return res;
        }
    }
        

       
        
    

   
}