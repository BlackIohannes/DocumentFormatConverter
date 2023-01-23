using System.Reflection;
using BLL.Interfaces;
using DATA.Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Document = iTextSharp.text.Document;

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
        var textOutput = File.ReadAllText("output.txt");
        Console.WriteLine("Text Output:");
        Console.WriteLine(textOutput);

        var jsonOutput = File.ReadAllText("output.json");
        if (!string.IsNullOrEmpty(jsonOutput))
        {
            try
            {
                var deserializedJson = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonOutput);
                Console.WriteLine("Json Output:");
                foreach (var item in deserializedJson)
                {
                    Console.WriteLine(item["Name"] + ": " + item["Description"]);
                    Console.WriteLine("Input: " + item["Input"]);
                    Console.WriteLine("Output: " + item["Output"]);
                }
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Json Output: Invalid Json");
            }
        }
        else
        {
            Console.WriteLine("Json Output: Empty File");
        }
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

        var json = JsonConvert.SerializeObject(output);
        File.WriteAllText("output.json", json);
    }

    public void GetDocsToPdf()
    {
        var doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream("output.pdf", FileMode.Create));
        doc.Open();
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            foreach (DocumentAttribute attribute in attributes)
            {
                doc.Add(new Paragraph($"{type.Name}: {attribute.Description}"));
                doc.Add(new Paragraph($"Input: {attribute.Input}"));
                doc.Add(new Paragraph($"Output: {attribute.Output}"));
            }

            var members = type.GetMembers();
            foreach (var member in members)
            {
                var memberAttributes = member.GetCustomAttributes(typeof(DocumentAttribute), true);
                foreach (DocumentAttribute attribute in memberAttributes)
                {
                    doc.Add(new Paragraph($"{member.Name}: {attribute.Description}"));
                    doc.Add(new Paragraph($"Input: {attribute.Input}"));
                    doc.Add(new Paragraph($"Output: {attribute.Output}"));
                }
            }
        }

        doc.Close();
    }
}
