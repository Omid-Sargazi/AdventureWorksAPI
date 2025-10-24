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
        }
       
    }
}