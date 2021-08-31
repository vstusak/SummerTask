using System.Xml.Linq;

namespace SummerTask
{
    public class XmlParser : IParser
    {
        public Document Parse(string input)
        {
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("Title").Value,
                Text = xdoc.Root.Element("Text").Value
            };
            return doc;
        }
    }
}
