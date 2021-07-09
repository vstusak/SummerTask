using System;
using System.CodeDom;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace SummerTask
{
    public class DocumentConverter
    {
        public void Execute(string sourceFileName, string targetFileName)
        {
            if (!FileValidation(sourceFileName))
            {
                throw new FileNotFoundException($"Input file '{sourceFileName}' not found.");
            }

            var settings = new Settings()
            {
                InputType = GetFileType(sourceFileName)
            };
            string input;

            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                input = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("Title").Value,
                Text = xdoc.Root.Element("Text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            File.WriteAllText(targetFileName, serializedDoc);
        }

        private InputType GetFileType(string sourceFileName)
        {
            var extension = Path.GetExtension(sourceFileName);
            var clearExtension = extension.Replace(".", "");

            if (Enum.TryParse(clearExtension, true, out InputType inputType))
            {
                return inputType;
            }

            throw new NotSupportedException($"Unsupported extension '{clearExtension}'");
        }

        private bool FileValidation(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}