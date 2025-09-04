namespace Sorting.SortingAlgorithem
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

        public void Inser(int vale)
        {
            heap.Add(vale);
            SiftUp(heap.Count - 1);

        }

        public int PeakMax()
        {
            if (IsEmpty) throw new InvalidOperationException("PriorityQueue is empty.");
            return
            heap[0];
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
                int parent = (current - 1) / 2;
                if (heap[parent] < heap[current])
                {
                    Swap(parent, current);
                    current = parent;
                }
                else break;
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
                if (left < n && heap[left] > heap[largest])
                    largest = left;

                if (right < n && heap[right] > heap[largest])
                    largest = right;

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
}