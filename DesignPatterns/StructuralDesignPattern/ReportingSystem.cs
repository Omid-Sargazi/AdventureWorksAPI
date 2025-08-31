namespace DesignPatterns.StructuralDesignPattern
{
    public interface IExportFormat
    {
        void GenerateFile(string data, string fileName);
    }

    public class PdfExport : IExportFormat
    {
        public void GenerateFile(string data, string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public class ExcelExport : IExportFormat
    {
        public void GenerateFile(string data, string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public class HtmlExport : IExportFormat
    {
        public void GenerateFile(string data, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}