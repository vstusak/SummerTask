using System;
using System.CodeDom.Compiler;
using System.IO;
using Newtonsoft.Json;

namespace SummerTask
{
    public class DocumentConverter
    {
        public void Convert(string sourceFileName, string targetFileName)
        {
            if (!FileHelper.FileValidation(sourceFileName))
            {
                throw new FileNotFoundException($"Input file '{sourceFileName}' not found.");
            }

            var settings = new Settings
            {
                InputType = FileHelper.GetFileType(sourceFileName)
            };

            //switch input type -> select xml xmlParser or json xmlParser
            var parser = ParserFactory(settings.InputType);
            
            var inputFileContent = FileHelper.OpenAsString(sourceFileName);

            var doc = parser.ParseDocument(inputFileContent);
            
            var serializedDoc = JsonConvert.SerializeObject(doc);

            File.WriteAllText(targetFileName, serializedDoc);
        }

        public IDocumentParser ParserFactory(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Xml:
                    return new XmlParser();
                case InputType.Json:
                    throw new NotImplementedException();
                case InputType.Html:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }

    }
}