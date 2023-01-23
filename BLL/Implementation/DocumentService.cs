using System.Reflection;
using BLL.Interfaces;
using DATA.Domain.Entities;

namespace BLL.Implementation;

[Document(Description = "Class", Input = "Takes in interfaces to be implemented", Output = "Results\n")]
public class DocumentService : DocumentAttribute, IDocument, IGetDocsToTextFiles, IGetDocsToJsonFiles, IPrintOutputs,
    IGetDocsToPdfs
{
    public void GetDocs()
    {
        HandleGetDocs();
        GetDocsToTextFile();
        GetDocsToJsonFile();
        PrintOutput();
        GetDocsToPdf();
    }

    [Document(Description = "A DocumentService Method", Input = "Method to handle getting documents",
        Output = "none\n")]
    public void HandleGetDocs()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            foreach (DocumentAttribute attribute in attributes)
            {
                Console.WriteLine($"{type.Name}: {attribute.Description}");
                Console.WriteLine($"Input: {attribute.Input}");
                Console.WriteLine($"Output: {attribute.Output}");
            }

            var members = type.GetMembers();
            foreach (var member in members)
            {
                var memberAttributes = member.GetCustomAttributes(typeof(DocumentAttribute), true);
                foreach (DocumentAttribute attribute in memberAttributes)
                {
                    Console.WriteLine($"{member.Name}: {attribute.Description}");
                    Console.WriteLine($"Input: {attribute.Input}");
                    Console.WriteLine($"Output: {attribute.Output}");
                }
            }
        }
    }

    public void GetDocsToTextFile()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        string output = "";
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            foreach (DocumentAttribute attribute in attributes)
            {
                output += $"{type.Name}: {attribute.Description} \r\n";
                output += $"Input: {attribute.Input} \r\n";
                output += $"Output: {attribute.Output} \r\n";
            }

            var members = type.GetMembers();
            foreach (var member in members)
            {
                var memberAttributes = member.GetCustomAttributes(typeof(DocumentAttribute), true);
                foreach (DocumentAttribute attribute in memberAttributes)
                {
                    output += $"{member.Name}: {attribute.Description} \r\n";
                    output += $"Input: {attribute.Input} \r\n";
                    output += $"Output: {attribute.Output} \r\n";
                }
            }
        }

        File.WriteAllText("output.txt", output);
    }

    public void PrintOutput()
    {
        Console.WriteLine("PrintOutput");
    }

    public void GetDocsToJsonFile()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var output = new List<Dictionary<string, string>>();
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            foreach (DocumentAttribute attribute in attributes)
            {
                var doc = new Dictionary<string, string>();
                doc.Add("Name", type.Name);
                doc.Add("Description", attribute.Description);
                doc.Add("Input", attribute.Input);
                doc.Add("Output", attribute.Output);
                output.Add(doc);
            }

            var members = type.GetMembers();
            foreach (var member in members)
            {
                var memberAttributes = member.GetCustomAttributes(typeof(DocumentAttribute), true);
                foreach (DocumentAttribute attribute in memberAttributes)
                {
                    var doc = new Dictionary<string, string>();
                    doc.Add("Name", member.Name);
                    doc.Add("Description", attribute.Description);
                    doc.Add("Input", attribute.Input);
                    doc.Add("Output", attribute.Output);
                    output.Add(doc);
                }
            }
        }

        // var json = JsonConverter.SerializeObject(output);
        // File.WriteAllText("output.json", json);
    }

    public void GetDocsToPdf()
    {
        Console.WriteLine("GetDocsToPdf");
    }
}
