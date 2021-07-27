using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerTask
{
    public class Converter
    {
        private readonly XmlParser _parser;
        private readonly JsonSerializer _serializer;
        private readonly FileReader _fileReader;
        private readonly FileWriter _fileWriter;

        public Converter(XmlParser parser, JsonSerializer serializer, FileReader fileReader, FileWriter fileWriter)
        {
            _parser = parser;
            _serializer = serializer;
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public void Convert(string sourceFileName, string targetFileName)
        {
            string input = _fileReader.Read(sourceFileName);

            Document doc = _parser.Parse(input);

            string serializedDoc = _serializer.Serialize(doc);

            _fileWriter.Write(targetFileName, serializedDoc);
        }
    }
}
