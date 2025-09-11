namespace DesignPatterns.Decoration
{
    public interface IDataSource
    {
        void WriteDate(string data);
        string ReadData();
    }

    public class FileDataSource : IDataSource
    {
        private string _data;
        public string ReadData()
        {
            Console.WriteLine("[File] Reading data...");
            return _data;
        }

        public void WriteDate(string data)
        {
            Console.WriteLine($"[File] Writing: {data}");
            _data = data;
        }
    }

    public abstract class DataSourceDecorator : IDataSource
    {
        protected readonly IDataSource _dataSource;
        public DataSourceDecorator(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public virtual string ReadData() => _dataSource.ReadData();

        public virtual void WriteDate(string data) => _dataSource.WriteDate(data);
    }

    public class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(IDataSource dataSource) : base(dataSource)
        {
        }

        public override string ReadData()
        {
            var data = base.ReadData();
            return data.Replace("[Compressed]", "");
        }
        public override void WriteDate(string data)
        {
            var compressed = $"[Compressed]{data}";
            Console.WriteLine("Compressing data...");
            base.WriteDate(compressed);
        }
    }

    public class EncryptionDecorator : DataSourceDecorator
    {
        public EncryptionDecorator(IDataSource dataSource) : base(dataSource)
        {
        }

        public override string ReadData()
        {
            var data = base.ReadData();
            var decrypted = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(data));
            return decrypted;
        }

        public override void WriteDate(string data)
        {
            var encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
            Console.WriteLine("Encrypting data...");
            base.WriteDate(encrypted);
        }
    }
}