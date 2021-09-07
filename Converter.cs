using SummerTask.Writing;
using System;
using System.IO;


namespace SummerTask
{
    public class Converter : IConverter
    {
        private IParser _parser;
        private ISerializer _serializer;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly IParserFactory _parserFactory;
        private readonly ISerializerFactory _serializerFactory;

        public Converter(IFileReader fileReader, IFileWriter fileWriter, IParserFactory parserFactory, ISerializerFactory serializerFactory)
        {
            //_serializer = serializer;
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _parserFactory = parserFactory;
            _serializerFactory = serializerFactory;
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            string input = _fileReader.Read(sourceFileName);

            _parser = _parserFactory.LoadParser(sourceFileName);

            Document doc = _parser.Parse(input);

            _serializer = _serializerFactory.LoadSerializer(targetFileName);
            string serializedDoc = _serializer.Serialize(doc);

            _fileWriter.Write(targetFileName, serializedDoc);
        }
    }
}
