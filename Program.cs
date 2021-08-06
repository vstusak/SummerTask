using System;
using System.IO;
using SummerTask.Parsers;
using SummerTask.Serializers;

namespace SummerTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // settings
            // validace souboru - existence souboru, validace obsahu
            // tridy na praci se souborem - FileOpener => FileParser => FileWriter
            // strategie na nacitani z disku, http
            // Reader/Writer - provider
            // factory na de/serializaci
            // nazvy souboru jako parametry - cesta z parametru
            // pridat logger
            // testy -  prubezne
            // pridat kontejnery
            // rozdelit do projektu
            // chceme vice output typu

            //./app source output-target*

            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "Output1.json");

            var fileHelper = new FileHelper();
            //var serializerFactory = new SerializeStrategyFactory();
            var serializer = new Serializer();
            var parser = new Parser();
            var documentConverter = new DocumentConverter(fileHelper, parser, serializer);
            documentConverter.Convert(sourceFileName, targetFileName);

            //var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            //var sw = new StreamWriter(targetStream);
            //sw.Write(serializedDoc);
        }
    }
}