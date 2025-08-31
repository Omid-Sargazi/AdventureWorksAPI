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

    public abstract class Report
    {
        protected readonly IExportFormat _exportFormat;

        public Report(IExportFormat exportFormat)
        {
            _exportFormat = exportFormat;
        }

        public abstract void Generate();
    }

    public class SalesReport : Report
    {
        private readonly string _salesData;
        public SalesReport(IExportFormat exportFormat, string salesData) : base(exportFormat)
        {
            _salesData = salesData;
        }

        public override void Generate()
        {
            Console.WriteLine("جمع‌آوری داده‌های فروش...");
            string reportContent = $"گزارش فروش: {_salesData}";
            _exportFormat.GenerateFile(reportContent, "SalesReport");
        }
    }

    public class InventoryReport : Report
    {
        private readonly string _inventoryData;

        public InventoryReport(IExportFormat exportFormat, string inventoryData)
            : base(exportFormat)
        {
            _inventoryData = inventoryData;
        }

        public override void Generate()
        {
            // منطق خاص گزارش موجودی
            Console.WriteLine("بررسی موجودی انبار...");
            string reportContent = $"گزارش موجودی: {_inventoryData}";

            _exportFormat.GenerateFile(reportContent, "InventoryReport");
        }
    }

}