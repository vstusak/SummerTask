using System;
using SummerTask.Serializers;

namespace SummerTask
{
    public class DocumentConverter : ParserFactory
    {
        private readonly FileHelper _fileHelper;
        private readonly IParser _parser;
        private readonly ISerializer _serializer;

        public DocumentConverter(FileHelper fileHelper, IParser parser, ISerializer serializer)
        {
            _fileHelper = fileHelper;
            _parser = parser;
            _serializer = serializer;
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

            //var serializer = _serializerFactory.GetStrategy(settings.OutputType);
            _serializer.SetStrategy(new SerializeStrategyFactory().GetStrategy(settings.OutputType));
            var serializedDoc = _serializer.SerializeDocument(doc);

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