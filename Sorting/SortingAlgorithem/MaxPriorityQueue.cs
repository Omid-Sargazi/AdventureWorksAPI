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

        }

        public void Inser(int vale)
        {
            heap.Add(vale);

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

    }
}