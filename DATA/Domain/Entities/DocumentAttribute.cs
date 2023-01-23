namespace DATA.Domain.Entities;

[AttributeUsage(AttributeTargets.All)]
public class DocumentAttribute : Attribute
{
    public string Description { get; set; }
    public string Input { get; set; }
    public string Output { get; set; }
}
