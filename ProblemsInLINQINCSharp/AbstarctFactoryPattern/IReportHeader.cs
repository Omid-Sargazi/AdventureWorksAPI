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
}