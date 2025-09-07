namespace Sorting.SortingAlgorithem
{
    public class MinPriorityQueue
    {
        private List<int> heap = new List<int>();

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
            SiftUp(heap.Count -1);
        }

        public int PeekMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Heap is empty");
            return heap[0];
        }

        public int ExtractMin()
        {
            if (IsEmpty) throw new InvalidOperationException("heap is empty");

            int min = heap[0];
            int lastindex = heap.Count - 1;

            heap[0] = heap[lastindex];
            heap.RemoveAt(lastindex);

            if (IsEmpty) SiftDown(0);

            return min;
        }

        private void SiftUp(int index)
        {
            int current = index;

            while (current > 0)
            {
                int parrent = (current - 1) / 2;
                if (heap[current] < heap[parrent])
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

                Swap(smallest, current);
                current = smallest;
            }

        }


        private void Swap(int i, int j)
        {
            (heap[i], heap[j]) = (heap[j], heap[i]);
        }

        private void BuildHeap()
        {
            int n = heap.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(i);
            }
        }
        public override string ToString() => string.Join(", ", heap);
    }
}