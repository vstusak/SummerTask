using System.Xml.Linq;

namespace SummerTask
{
    public class XmlParser : IDocumentParser
    {
        public Document ParseDocument(string input)
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
