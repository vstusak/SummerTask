using System.Xml.Linq;

namespace SummerTask.Parsers
{
    public class XmlParsingStrategy : IParsingStrategy
    {
        public Document Parse(string input)
        {
            var xmlDocument = XDocument.Parse(input);
            return new Document
            {
                Title = xmlDocument.Root.Element("Title").Value,
                Text = xmlDocument.Root.Element("Text").Value
            };
        }
    }
}
