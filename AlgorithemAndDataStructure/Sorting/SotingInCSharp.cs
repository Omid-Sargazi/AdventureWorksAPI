namespace AlgorithemAndDataStructure.Sorting
{
    public class SotingInCSharp
    {
        public static void QuickSort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivot = Partition(arr, lo, hi);
                QuickSort(arr, lo, pivot - 1);
                QuickSort(arr, pivot + 1, hi);

            }
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];
            int i = lo - 1;

            for (int j = lo; j < hi; j++)
            {
                if (arr[j] < arr[pivot])
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }

            return i + 1;
        }


    }

    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger() { }

        public static Logger Instance => _instance;
    }

    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    public class WinButton : IButton
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }

    public class WinCheckbox : ICheckbox
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }

    public class MacButton : IButton
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }

    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            throw new NotImplementedException();
        }
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }


    public class ClientFactory
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        public ClientFactory(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void RenderUI()
        {
            _button.Render();
            _checkbox.Render();
        }
    }

}