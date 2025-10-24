namespace SamplePlugin.AttributePlugin
{

    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute: Attribute
    {
        public string? Description { get; set; }
        public ExportAttribute(string? description)
        {
            Description = description;
        }    
    }
}