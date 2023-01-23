using BLL.Implementation;

namespace UI.AppScreenDisplay;

public class AppScreen
{
    public static void Run()
    {
        DocumentService documentService = new DocumentService();
        documentService.GetDocs();
    }
}
