using System;

namespace SummerTask
{
    public class ParserFactory
    {



        public IParsingStrategy GetParser(FileType inputType)
        {
            switch (inputType)
            {
                case FileType.Xml:
                    return new XmlParsingStrategy();
                case FileType.Json:
                    return new JsonParsingStrategy();
                case FileType.Html:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
            }
        }
    }
}