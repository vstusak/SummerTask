namespace SummerTask
{
    public class Converter
    {
        private IParser _parser;
        private readonly JsonSerializer _serializer;
        private readonly FileReader _fileReader;
        private readonly FileWriter _fileWriter;
        private readonly ParserFactory _parserFactory;
        public Converter(JsonSerializer serializer, FileReader fileReader, FileWriter fileWriter, ParserFactory parserFactory)
        {
            _serializer = serializer;
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _parserFactory = parserFactory;
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            string input = _fileReader.Read(sourceFileName);

            _parser = _parserFactory.LoadParser(sourceFileName);

            Document doc = _parser.Parse(input);

            string serializedDoc = _serializer.Serialize(doc);

            _fileWriter.Write(targetFileName, serializedDoc);
        }
    }
}
