namespace LiveCoding.MyCollections
{
    public interface ISimpleEnumerator
    {
        bool MoveNext();
        int Current { get;}
        void Reset();
    }

    public class SimpleEnumerator : ISimpleEnumerator
    {
        private int[] _numbers;
        private int _currentIndex = -1;
        public SimpleEnumerator(int[] numbers)
        {
            _numbers = numbers;
        }
        public int Current
        {
            get
            {
                if (_currentIndex == -1 || _currentIndex >= _numbers.Length)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _numbers[_currentIndex];
                }
            }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _numbers.Length;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
    public class MyCollection
    {
        private int[] _numbers = { 1, 2, 3, 4, 5, 6 };

        public ISimpleEnumerator GetEnumerator()
        {
            return new SimpleEnumerator(_numbers);
        }
    }

    public class ClientMyCollection
    {
        public static void Run()
        {
           
        }

        
    }
}