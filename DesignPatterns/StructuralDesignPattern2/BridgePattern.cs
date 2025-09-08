namespace DesignPatterns.StructuralDesignPattern2
{
    public interface IGenerateReport
    {
        void GenerateFile(string data, string fileName);
    }

    public class ExcelReport : IGenerateReport
    {
        private string _data;
        private string _fileName;
        public ExcelReport(string data, string fileName)
        {
            _data = data;
            _fileName = fileName;
        }
        public void GenerateFile(string data, string fileName)
        {
            Console.WriteLine($" generated excell {_data} with name{_fileName}");
        }
    }

    public class PdfReport : IGenerateReport
    {
        private string _data;
        private string _fileName;

        public PdfReport(string data, string fileName)
        {
            _data = data;
            _fileName = fileName;
        }

        public void GenerateFile(string data, string fileName)
        {
            Console.WriteLine($" generated pdf {_data} with name{_fileName}");
        }
    }

    public abstract class Report
    {
        protected readonly IGenerateReport _generateReport;

        public Report(IGenerateReport generateReport)
        {
            _generateReport = generateReport;
        }

        public abstract void Generate();
    }

    public class ReportFromManager : Report
    {
        private string _data;
        private string _name;
        public ReportFromManager(string data, string name, IGenerateReport generateReport) : base(generateReport)
        {
            _data = data;
            _name = name;
        }

        public override void Generate()
        {
            _generateReport.GenerateFile(_data, _name);
        }
    }

    public class ReportFromEmployee : Report
    {
        private string _data;
        private string _name;
        public ReportFromEmployee(string data, string name, IGenerateReport generateReport) : base(generateReport)
        {
            _data = data;
            _name = name;
        }

        public override void Generate()
        {
            _generateReport.GenerateFile(_data, _name);
        }
    }

    public class ClientReport
    {
        public static void Run()
        {
            var excel = new ExcelReport("exelContext", "names.excel");
            var pdf = new PdfReport("pdfContext", "names.pdf");

            var employee = new ReportFromEmployee("data from omid", "omid", excel);
            employee.Generate();
        }
    }
}