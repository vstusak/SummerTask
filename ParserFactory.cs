using System;

namespace SummerTask
{
    public class ParserFactory
    {



        public IDocumentParser GetParser(FileType inputType)
        {
            switch (inputType)
            {
                case FileType.Xml:
                    return new XmlParser();
                case FileType.Json:
                    throw new NotImplementedException();
                case FileType.Html:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}