using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SummerTask.Writing
{
    public class XmlSummerSerializer : ISerializer
    {
        public string Serialize(Document doc)
        {
            var xmlDocument = new XDocument(
                    new XElement("root", 
                        new XElement("title", doc.Title),
                        new XElement("text", doc.Text)
                       )
                );
            return xmlDocument.ToString();
        }
    }
}
