using System;
using System.IO;

namespace SummerTask
{
    public class ParserFactory
    {
        public IParser LoadParser(string sourceFileName)
        {
            var fileExtension = new FileInfo(sourceFileName).Extension.Trim('.');

            switch (fileExtension)
            {
                case "xml":
                    return new XmlParser();
                case "json":
                    return new JsonParser();
                default:
                    throw new NotImplementedException($"Unsupported file extension: {fileExtension}");
            }
        }
    }
}
