using System;
using System.IO;

namespace SummerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new JsonSerializer();
            var fileReader = new FileReader();
            var fileWriter = new FileWriter();
            var parserFactory = new ParserFactory();

            var converter = new Converter(serializer,fileReader,fileWriter, parserFactory);
            //Create example files
            //Finally: Load from args instead
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            //Pick parser based on source file
            //Pick serializer based on source file
            converter.Convert(sourceFileName, targetFileName);
        }
    }
}
