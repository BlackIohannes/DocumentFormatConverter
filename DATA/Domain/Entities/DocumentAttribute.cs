namespace DATA.Domain.Entities;

[AttributeUsage(AttributeTargets.All)]
[Document(Description = "Models", Input = "Content models", Output = "none")]
public class DocumentAttribute : Attribute
{
    [Document(Description = "Stores description", Input = "none", Output = "none\n")]
    public string Description { get; set; }

    [Document(Description = "Stores input", Input = "none", Output = "none\n")]
    public string Input { get; set; }

    [Document(Description = "Returns output", Input = "none", Output = "none\n")]
    public string Output { get; set; }
}
