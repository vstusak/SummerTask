using System;

namespace SummerTask
{
    public class DocumentConverter : ParserFactory
    {
        private readonly FileHelper _fileHelper;
        private readonly SerializerFactory _serializerFactory;
        private readonly IParser _parser;

        public DocumentConverter(FileHelper fileHelper, SerializerFactory serializerFactory, IParser parser)
        {
            _fileHelper = fileHelper;
            _serializerFactory = serializerFactory;
            _parser = parser;
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            var settings = new Settings
            {
                InputType = _fileHelper.GetFileType(sourceFileName),
                OutputType = _fileHelper.GetFileType(targetFileName)
            };

            _parser.SetStrategy(GetParsingStrategy(settings.InputType));

            var inputFileContent = _fileHelper.OpenAsString(sourceFileName);
            var doc = _parser.ParseDocument(inputFileContent);

            var serializer = _serializerFactory.GetSerializer(settings.OutputType);
            var serializedDoc = serializer.Serialize(doc);

            _fileHelper.WriteFile(targetFileName, serializedDoc);
        }

        private IParsingStrategy GetParsingStrategy(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Xml:
                    return new XmlParsingStrategy();
                    
                case FileType.Json:
                    return new JsonParsingStrategy();
                    
                case FileType.Html:
                    throw new NotImplementedException();
                    
                default:
                    throw new Exception(); //TBD Incompatible file type
            }
        }
    }
}