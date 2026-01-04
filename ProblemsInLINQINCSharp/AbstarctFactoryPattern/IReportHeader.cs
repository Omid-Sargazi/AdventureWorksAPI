namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
    public interface IReportHeader
{
    string Generate();
}

public interface IReportBody
{
    string Generate(List<object> data);
}

public interface IReportFooter
{
    string Generate(DateTime generatedTime);
}

// Concrete Products for PDF
public class PdfReportHeader : IReportHeader
{
    public string Generate() => "PDF Header: ========================";
}

public class PdfReportBody : IReportBody
{
    public string Generate(List<object> data)
    {
        var body = "PDF Body:\n";
        foreach (var item in data)
        {
            body += $"• {item}\n";
        }
        return body;
    }
}

public class PdfReportFooter : IReportFooter
{
    public string Generate(DateTime generatedTime) 
        => $"PDF Footer - Generated at: {generatedTime}\n========================";
}



// Concrete Products for Excel
public class ExcelReportHeader : IReportHeader
{
    public string Generate() => "Excel Header: --------------------";
}

public class ExcelReportBody : IReportBody
{
    public string Generate(List<object> data)
    {
        var body = "Excel Body:\n";
        foreach (var item in data)
        {
            body += $"- {item}\n";
        }
        return body;
    }
}

public class ExcelReportFooter : IReportFooter
{
    public string Generate(DateTime generatedTime) 
        => $"Excel Footer - Created: {generatedTime}\n--------------------";
}

public interface IReportFactory
{
    IReportHeader CreateHeader();
    IReportBody CreateBody();
    IReportFooter CreateFooter();
}

public class PdfReportFactory : IReportFactory
{
    public IReportHeader CreateHeader() => new PdfReportHeader();
    public IReportBody CreateBody() => new PdfReportBody();
    public IReportFooter CreateFooter() => new PdfReportFooter();
}

public class ExcelReportFactory : IReportFactory
{
    public IReportHeader CreateHeader() => new ExcelReportHeader();
    public IReportBody CreateBody() => new ExcelReportBody();
    public IReportFooter CreateFooter() => new ExcelReportFooter();
}

public class ReportGenerator
{
    private readonly IReportHeader _header;
    private readonly IReportBody _body;
    private readonly IReportFooter _footer;

    public ReportGenerator(IReportFactory factory)
    {
        _header = factory.CreateHeader();
        _body = factory.CreateBody();
        _footer = factory.CreateFooter();
    }

    public string GenerateReport(List<object> data)
    {
        var report = _header.Generate() + "\n";
        report += _body.Generate(data) + "\n";
        report += _footer.Generate(DateTime.Now);
        return report;
    }
}
}