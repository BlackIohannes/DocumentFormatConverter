# In-house Code Documentation Tool With Document Format Converter.

This tool is designed to annotate Classes, Methods, Properties, Enums, and other code elements with a Document Attribute. The Document Attribute takes one required parameter "Description" and two optional Parameters "Input" and "Output" respectively.

## Getting Started

To use this tool, you will need to install the following packages:
1. Newtonsoft.Json
2. iTextSharp

You can install these packages using the NuGet Package Manager in Visual Studio by running the following commands in the Package Manager Console:

`Install-Package Newtonsoft.Json
`

and

`Install-Package iTextSharp
`

## Using the Tool
### Document Attribute

To annotate a code element with the Document Attribute, you will need to include the attribute above the element you wish to document. Here is an example of how to use the attribute:

```
[Document("This is the description of the class", "input", "output")]
public class MyClass
{
    // class implementation
}
```

## GetDocs() Method

To display details of all codes documented throughout the assembly, you can call the GetDocs() method. The method has three options for displaying the output:
Text file in text format

You can call the GetDocsToTextFile() method to write the output to a text file in text format.

`DocumentService.GetDocsToTextFile();
`

Json file in Json format

You can call the GetDocsToJsonFile() method to write the output to a json file in json format.

`DocumentService.GetDocsToJsonFile();
`

Read both files and print their output on the console

You can call the PrintOutput() method to read both files and print their output on the console.

`DocumentService.PrintOutput();
`

Output to a pdf file

You can call the GetDocsToPdf() method to write the output to a pdf file as plain text.

`DocumentService.GetDocsToPdf();
`

Please note that the output pdf file will be created in the same directory where your project is located, and the file name will be output.pdf

## Error Handling

The PrintOutput() method includes a null check and check the content of the json file before deserializing it. If the json file is empty or invalid, the method will write "Json Output: Empty File" or "Json Output: Invalid Json" to the console accordingly.

Please let me know if you have any further questions or if there are any other issues.
## Conclusion

This tool provides an easy way to document your code and generate a well-formatted report. It's simple to use and you can easily create a text or json file or pdf file with all the documented code elements. The tool also includes error handling to handle empty or invalid json files.
