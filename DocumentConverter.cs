namespace SummerTask
{
    public class DocumentConverter : ParserFactory
    {
        private readonly FileHelper _fileHelper;
        private readonly ParserFactory _parserFactory;
        private readonly SerializerFactory _serializerFactory;

        public DocumentConverter(FileHelper fileHelper, ParserFactory parserFactory, SerializerFactory serializerFactory)
        {
            _fileHelper = fileHelper;
            _parserFactory = parserFactory;
            _serializerFactory = serializerFactory;
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            var settings = new Settings
            {
                InputType = _fileHelper.GetFileType(sourceFileName),
                OutputType = _fileHelper.GetFileType(targetFileName)
            };

            //switch input type -> select xml xmlParser or json xmlParser
            var parser = _parserFactory.GetParser(settings.InputType);

            var inputFileContent = _fileHelper.OpenAsString(sourceFileName);
            var doc = parser.ParseDocument(inputFileContent);

            var serializer = _serializerFactory.GetSerializer(settings.OutputType);
            var serializedDoc = serializer.Serialize(doc);

            _fileHelper.WriteFile(targetFileName, serializedDoc);
        }
    }
}