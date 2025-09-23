namespace AlgorithemInCSharp.SimpleResource
{
    public class SimpleResource : IDisposable
    {
        private string _name;
        private bool _disposed = false;
        public SimpleResource(string name)
        {
            _name = name;
            Console.WriteLine($"Acquiring resource: {_name}");
        }

        public void DoWork()
        {
            if (_disposed)
                throw new ObjectDisposedException(_name);
            Console.WriteLine($"⚡ {_name} در حال کار...");
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine("Disposing SimpleResource");
                _disposed = true;
            }
        }
    }

    public class RunSimpleResource
    {
        public static void Run()
        {
            Console.WriteLine("Starting resource management...");
            using (var resource1 = new SimpleResource("esource1"))
            {
                resource1.DoWork();
                resource1.DoWork();
            }
            Console.WriteLine("---");

            var resource2 = new SimpleResource("منبع شماره ۲");
            resource2.DoWork();

            Console.WriteLine("Ending resource management...");
        }

        private static void TestWithUsing()
        {
            using (var resource1 = new SimpleResource("Source1"))
            {
                resource1.DoWork();
                resource1.DoWork();
            }

            Console.WriteLine("---");
            Console.WriteLine("source1 is disposed here.");
        }

        static void TestWithoutUsing()
        {
            SimpleResource resource3 = new SimpleResource("source3");
            SimpleResource resource4 = null;

            try
            {
                resource3 = new SimpleResource("source3");
                resource3.DoWork();
                throw new Exception("An error occurred during work.");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception caught: {ex.Message}");
            }
            finally
            {
                resource3?.Dispose();
                resource4?.Dispose();
                Console.WriteLine("Resources disposed in finally block.");
            }

        }
    }
}