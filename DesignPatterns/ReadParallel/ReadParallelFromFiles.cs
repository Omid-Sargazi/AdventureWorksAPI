using System.Formats.Asn1;
using System.Text;

namespace DesignPatterns.ReadParallel
{
    public class ReadParallelFromFiles
    {
        public static void Run()
        {
            string directoryPath = "Files";

            Directory.CreateDirectory(directoryPath);


            try
            {
                // Create the file, or overwrite if the file exists.
                for (int i = 0; i < 500; i++)
                {
                    string path = Path.Combine(directoryPath, $"file{i}.txt");
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes($"This is some text in the file{i}.");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            // for (int i = 0; i < 500; i++)
            // {
            //     string filepath = Path.Combine(directoryPath, $"file{i}.txt");
            //     using (StreamReader sr = File.OpenText(filepath))
            //     {
            //         string s = "";
            //         while ((s = sr.ReadLine()) != null)
            //         {
            //             Console.WriteLine(s);
            //         }
            //     }
            // }
        }

    }


    public class ReadFile
    {
        private readonly string _filePath;
        private readonly string _fileName;

        public ReadFile(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }
        public async Task<string> ReadFileAsync()
        {
            string directoryPath = _filePath;
            string filePath = Path.Combine(directoryPath, _fileName);

            return await File.ReadAllTextAsync(filePath);

        }
    }

    public class ClientParallelReadFiles
    {
        private List<Task<string>> _tasks = new List<Task<string>>();

        public async Task Execute()
        {
            string directoryPath = "Files";
            for (int i = 0; i < 500; i++)
            {
                var res = new ReadFile(directoryPath, $"file{i}.txt");
                _tasks.Add(res.ReadFileAsync());
            }


            string[] results = await Task.WhenAll(_tasks);

            Console.WriteLine($"{string.Join(",",results)}");
        }
    }
}