using System.Globalization;

namespace DataStructure.SimpleResource
{
    public class SimpleResource : IDisposable
    {
        private string _name;
        private bool _disposed = false;

        public SimpleResource(string name)
        {
            _name = name;
            Console.WriteLine($"{_name} actived");
        }

        public void DoWork()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(_name);
            }

            Console.WriteLine($"{_name} is working...");
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine($"{_name} already disposed.");
                _disposed = true;
            }
        }
    }

    public class RunSimpleResource
    {
        public static void Run()
        {
            Console.WriteLine("Test with using...");
            TestWithUsing();


            Console.WriteLine("Test without using...");
            TestWithoutUsing();

            Console.WriteLine("Dangerous Test...");
            TestDangerousScenario();

        }


        private static void TestWithUsing()
        {
            using (var resource1 = new SimpleResource("Source1"))
            {
                resource1.DoWork();
                resource1.DoWork();
            }

            Console.WriteLine("source1 is closed...");
            Console.WriteLine("---");
        }

        private static void TestWithoutUsing()
        {
            var resource2 = new SimpleResource("source2");
            resource2.DoWork();
            // resource2 opned until GC collected it;
        }

        private static void TestDangerousScenario()
        {
            SimpleResource resource3 = null;

            try
            {
                resource3 = new SimpleResource("source3");
                resource3.DoWork();
                throw new Exception("Simulated failure");
            }
            catch (Exception ex)
            {

                Console.WriteLine("get an error{0}", ex.Message);
            }
            finally
            {
                resource3?.Dispose();
            }
        }
    }
}