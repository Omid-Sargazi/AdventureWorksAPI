namespace HeapBinary.MaxHeapBinary
{
    public class MaxHeap
    {
        private List<int> _heap;

        public MaxHeap()
        {
            _heap = new List<int>();
        }

        public void Add(int value)
        {
            _heap.Add(value);

            int index = _heap.Count -1;
            while(index>0)
            {
                int parentIndex = (index-1)/2;

                if(_heap[index]>_heap[parentIndex])
                {
                    (_heap[index],_heap[parentIndex]) = (_heap[parentIndex],_heap[index]);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public int RemoveMax()
        {
            if(_heap.Count==0) throw new Exception("Heap خالی است!");

            int max = _heap[0];

            _heap[0] = _heap[^1];
            _heap.RemoveAt(_heap.Count-1);

            int index=0;

            while(true)
            {
                int leftChild = 2*index+1;
                int rightChild = 2*index+2;

                int largest = index;

                if(leftChild<_heap.Count && _heap[leftChild]>_heap[largest])
                {
                    largest = leftChild;
                }

                if(rightChild<_heap.Count && _heap[rightChild]>_heap[largest])
                {
                    largest = rightChild;
                }

                if (largest != index)
            {
                (_heap[index], _heap[largest]) = (_heap[largest], _heap[index]);
                index = largest;
            }
            else
            {
                break;
            }
            }

            return max;
        }

         public int Peek()
    {
        if (_heap.Count == 0)
            throw new Exception("Heap خالی است!");
        return _heap[0];
    }
    
    public void Print()
    {
        Console.WriteLine("Heap: " + string.Join(", ", _heap));
    }
    }
}