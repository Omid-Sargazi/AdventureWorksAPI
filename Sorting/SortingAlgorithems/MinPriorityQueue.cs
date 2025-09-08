namespace Sorting.SortingAlgorithems
{
    public class MinPriorityQueuee
    {
        private List<int> heap = new List<int>();

        public MinPriorityQueuee() { }
        public MinPriorityQueuee(IEnumerable<int> items)
        {
            heap = new List<int>(items);
            BuildHeap();
        }

        public void Insert(int value)
        {
            heap.Add(value);
            SiftUp(heap.Count -1);
        }

        public int Count => heap.Count;
        public bool IsEmpty => heap.Count == 0;

        public int PeekMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Heap is Empty");
            return heap[0];
        }

        public int ExtractMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Heap is Empty");

            int min = heap[0];
            int lastIndex = heap.Count;

            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            if (!IsEmpty) SiftDown(0);
            return min;
        }

        private void SiftUp(int index)
        {
            int current = index;
            while (current > 0)
            {
                int parrent = (current - 1) / 2;
                if (heap[parrent] > heap[current])
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
                int smallest = current;

                if (left < n && heap[left] < heap[current])
                    smallest = left;

                if (right < n && heap[right] < heap[smallest])
                    smallest = right;

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