﻿using SummerTask.Writing;
using System;
using System.IO;


namespace SummerTask
{
    public class Converter 
    {
        private IParser _parser;
        private ISerializer _serializer;
        private readonly FileReader _fileReader;
        private readonly FileWriter _fileWriter;
        private readonly ParserFactory _parserFactory;
        private readonly SerializerFactory _serializerFactory;
        public Converter(FileReader fileReader, FileWriter fileWriter, ParserFactory parserFactory, SerializerFactory serializerFactory)
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
