namespace DesignPatterns.StructuralDesignPattern
{
    public interface IFile
    {
        string Name { get; }
        long GetSize();
        void Display(string indent = "");
    }

    public class SimpleFile : IFile
    {
        public string Name { get; }
        protected long Size { get; set; }
        public SimpleFile(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}' ' {Name}' ' {Size} ' 'MB");
        }

        public long GetSize()
        {
            return Size;
        }
    }

    public class Folder : IFile
    {
        public string Name { get; }

        private List<IFile> _files = new();
        public Folder(string name)
        {
            Name = name;
        }

        public void AddComponent(IFile file)
        {
            _files.Add(file);
        }

        public void RemoveComponent(IFile file)
        {
            _files.Remove(file);
        }

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent} {Name}");
            foreach (var item in _files)
            {
                item.Display(indent + " ");
            }

        }

        public long GetSize()
        {
            long totalSize = 0;
            foreach (var com in _files)
            {
                totalSize += com.GetSize();
            }

            return totalSize;
        }
    }
}