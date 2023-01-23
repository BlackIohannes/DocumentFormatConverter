using DATA.Domain.Entities;

namespace BLL.Interfaces;

public interface IDocument
{
    [Document(Description = "Interface that implements GetDocs", Input = "Just input", Output = "Just output\n")]
    void GetDocs();

    void HandleGetDocs();
}
