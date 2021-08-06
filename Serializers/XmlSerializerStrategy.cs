using System.Xml.Linq;

namespace SummerTask.Serializers
{
    public class XmlSerializerStrategy : ISerializeStrategy
    {
        public string Serialize(Document document)
        {
            var xmlDocument = new XDocument(
                new XElement("Root",
                    new XElement("Title", document.Title),
                    new XElement("Text", document.Text)
                )
            );

            return xmlDocument.ToString();
        }
    }
}