using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SummerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new XmlParser();
            var serializer = new JsonSerializer();
            var fileReader = new FileReader();
            var fileWriter = new FileWriter();
            var converter = new Converter(parser, serializer,fileReader,fileWriter);
            //Create example files
            //Finally: Load from args instead
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");


            //Pick parser based on source file
            //Pick serializer based on source file
            converter.Convert(sourceFileName, targetFileName);
        }
    }

    public interface IDocument
    {
        string Title { get; set; }
        string Text { get; set; }
    }

    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
